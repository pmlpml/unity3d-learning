---
layout: default
title: 协程与Unity
---

# 附录 X3-06、协程与Unity
{:.no_toc}

* 目录
{:toc}


## 1、进程、线程与协程

> 进程（Process）是执行中的程序，是操作系统管理、分配资源（CPU、内存、IO等）的单位。简单的，进程运行在由操作系统提供的虚拟计算机上，进程之间是隔离的，进程间只能通过管道、共享文件、网络相互通讯。具体见操作系统教程

> 线程（Thread）是进程中并发执行的函数（任务），有自己的栈和上下文环境，是操作系统能够进行资源调度的最小单位。一个进程至少有一个线程（main），应用线程可直接由操作系统线程库管理，也可由编程语言提供的库调度，线程之间共享进程的所拥有的资源。多线程可跟好的利用多CPU资源，但协同机制大大提升了编程难度

> 协程（Coroutine）是一个有应用程序自己调度的并发函数，有自己的栈和上下文环境，采用 **非抢占式调度**。协程的优势是避免了频繁线程调度的开销，单线程也能产生并发效果，由于在一个线程中能仅能有一个协程执行，减少的资源冲突。它功能虽然很像线程，但是必须由编译或用户编程代码切换线程。维基百科的解释是：协同程序是一种计算机程序组件，它通过允许暂停和恢复执行，将子程序泛化以实现无优先级的多任务处理。协同程序非常适合实现类似的程序组件，如协作任务、异常、事件循环、迭代器、无限列表和管道。 

> go-routine 或 fiber 是协程，它们有一个单线程或多线程的调度器调度，当协程被挂起后自动执行其他协程。

## 2、C# 的协程机制 与 Unity

### 2.1 C# 生成器模式与 yield 关键字

C# 使用生成器（Generator）模式协同机制，一个函数使用 yield 关键字产生一个对象的序列，通过 IEnumerator 接口对象遍历这个序列。以下是 Unity 中的一个脚本，它管理了 Generator 函数的两个实例，并调度它们运行。代码如下：

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineDemo : MonoBehaviour {

	private IEnumerator<int> gen1,gen2;

	// Use this for initialization
	void Start () {
		gen1 = Generator (0);
		gen2 = Generator (100);
		print ("exec start work or not ?");
	}
	
	// Update is called once per frame
	void Update () {
		if (gen1.MoveNext ())
			print ("gen1: " + gen1.Current);
		if (gen2.MoveNext ())
			print ("gen2: " + gen2.Current);
	}

	IEnumerator<int> Generator(int start) {
		print ("start work! " + start);
		yield return start;
		for (int i = 1; i <= 10; i++) {
			print ("next work! " + start + i);
			yield return start + i;
		}
	}
}
```

请运行以上代码。

**语法**

* C# 的协程就是一个函数。函数必须返回实现迭代器接口（[IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8)）的匿名对象（协程上下文）
* 协程函数必须使用 [yield](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield) 关键字返回一个值（yield return value）或 终止协程（yield break）

**创建协程**

* 编译器确定一个函数是协程，编译后协程函数执行过程是：
    - 在堆上创建协程上下文对象和函数实例（栈），并不执行代码
	- 返回协程上下文（包含协程ID，将执行函数代码指针，当前返回值，函数实例的栈指针等）对象引用给调用者。
* 案例中，start 函数中创建了两个 Generator 协程，并返回了它们的上下文对象
    - 这时函数并没有执行
	- 每个协程实例在堆中有独立的函数栈，并压入了参数
	- 代码指针指向首行代码
	- 当前返回值为默认值或 null
* 由于 Generator 函数没有执行，所以先打印 `exec start work or not ?` 

**调度、执行协程**

* 案例中，update 函数在调度并执行协程
* 上下文对象实现了 IEnumerator 接口
    - 当调用 MoveNext() 方法后，该协程执行直到遇到 yield 或 协程结束（yield break）
	- yield 语句的任务是将 return value 写入上下文对象当前值，代码指针指向下一行
	- 程序返回调度程序
* 调度程序根据上下文对象返回值决定下一次调度

表面上，两个 Generator 函数是并发的，但执行顺序是代码控制的（多线程调度器执行顺序不一定有序）。

* 这个[博客](https://blog.csdn.net/bdss58/article/details/74779606) 给出了 python、nodejs、golang 生成器的实现

### 2.2 Unity 协程实现与游戏循环

现在阅读 MonoBehaviour 的 [StartCoroutine 方法](https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html)就很清晰了。

* StartCoroutine 将协程的上下文添加到该行为协程管理器中
* 游戏循环会驱动该行为中协程的执行

Unity 引擎预定义一些协程返回值，我们可以从 [Execution Order of Event Functions](https://docs.unity3d.com/Manual/ExecutionOrder.html) 中找到它们：

* yield null The coroutine will continue after all Update functions have been called on the next frame.
* yield WaitForSeconds Continue after a specified time delay, after all Update functions have been called for the frame
* yield WaitForFixedUpdate Continue after all FixedUpdate has been called on all scripts
* yield WWW Continue after a WWW download has completed.
* yield StartCoroutine Chains the coroutine, and will wait for the MyFunc coroutine to complete first.

在游戏循环 Physics 阶段的最后处理

* yield WaitForFixedUpdate

在游戏循环 GameLogic 阶段的开始依次处理：

* yield null
* yield WaitForSeconds
* yield WWW Continue

在游戏循环 End of frame 阶段

* yield WaitForEndOfFrame

当然你可以自己定义协程执行条件，仅需要继承 [CustomYieldInstruction](https://docs.unity3d.com/ScriptReference/CustomYieldInstruction.html)

## 3、Unity 协程的应用

官方文档 [Coroutines](https://docs.unity3d.com/Manual/Coroutines.html) 可以管理动作过程，如 Fading。

一个疑问用 update 不是挺方便？

事实是 Coroutines 有生命周期的（从创建到函数执行结束），而且是每个协程都是独立的函数实例。如果游戏对象的基本动作都用协程管理？。。。

不错！[Dotweem](http://dotween.demigiant.com/) 这个产品就是这样思考的！

协程、方法扩展、Lambda 表达式 等编程技巧，让 Unity 编程产生了梦幻般的效果。


