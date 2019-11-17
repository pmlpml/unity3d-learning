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

> 协程（Coroutine）是一个有应用程序自己调度的并发函数，有自己的栈和上下文环境，采用非抢占式调度。协程的优势是避免了频繁线程调度的开销，单线程也能产生并发效果，由于在一个线程中能仅能有一个协程执行，减少的资源冲突。它功能虽然很像线程，但是必须由编译或用户编程代码切换线程。

> go-routine 或 fiber 是协程，它们有一个单线程或多线程的调度器调度，当协程被挂起后自动执行其他协程。

## 2、C# 的协程机制 与 Unity

### 2.1 C# 生成器模式与 yield 关键字

C# 使用生成器（Generator）模式协同机制，使用 yield 关键字生成一个 IEnumerator 接口对象的序列。yield 语句的原理是把下一条语句的地址放入协程函数上下文，并把函数返回值发送到 IEnumerator 对象。调度者读取 IEnumerator 对象返回的值，并通过 IEnumerator 的 MoveNext() 方法执行生成器函数的后续语句，直到生成器函数执行完毕。

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

显然，执行 yield 关键字返回的函数，直接返回了一个可迭代的对象或迭代器，并在函数上下文中记录了函数起始执行地址。当调度者（这里是 update 函数）使用迭代器的 MoveNext 方法执行当前协程（Generator函数），直到 yield 语句出现，并把放回值放置到 Current 中。表面上，两个 Generator 函数是并发的，但执行顺序是代码控制的（多线程调度器执行顺序不一定有序）。

* 这个[博客](https://blog.csdn.net/bdss58/article/details/74779606) 给出了 python、nodejs、golang 生成器的实现

### 2.2 Unity 协程实现与游戏循环

现在阅读 MonoBehaviour 的 [StartCoroutine 方法](https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html)就很清晰了。它的参数就是 IEnumerator 接口对象，通常是 Generator 函数的返回值。这样做的目的就是在游戏调度器（游戏循环）中维持一个 Generator 函数（协程）列表，游戏循环根据 yield return 的返回值（[YieldInstruction](https://docs.unity3d.com/ScriptReference/YieldInstruction.html)）决定什么时刻决定继续执行该函数。

Unity 引擎预定义一些返回值，我们可以从 [Execution Order of Event Functions](https://docs.unity3d.com/Manual/ExecutionOrder.html) 中找到它们：

* yield null The coroutine will continue after all Update functions have been called on the next frame.
* yield WaitForSeconds Continue after a specified time delay, after all Update functions have been called for the frame
* yield WaitForFixedUpdate Continue after all FixedUpdate has been called on all scripts
* yield WWW Continue after a WWW download has completed.
* yield StartCoroutine Chains the coroutine, and will wait for the MyFunc coroutine to complete first.

在游戏循环 Physics 阶段最后处理

* yield WaitForFixedUpdate

在游戏循环 GameLogic 阶段的开始依次处理：

* yield null
* yield WaitForSeconds
* yield WWW Continue
* yield WWW Continue

在游戏循环 End of frame 阶段

* yield WaitForEndOfFrame

当然你可以自己定义协程执行条件，仅需要继承 [CustomYieldInstruction](https://docs.unity3d.com/ScriptReference/CustomYieldInstruction.html)


## 3、Unity 协程的应用

官方文档 [Coroutines](https://docs.unity3d.com/Manual/Coroutines.html) 可以管理动作过程，如 Fading。

一个疑问用 update 不是挺方便？

事实是 Coroutines 有生命周期的（从创建到函数执行结束），而且是每个协程都是独立的函数实例。如果游戏对象的基本动作都用协程管理？。。。

不错！Dotweem 这个产品就是这样思考的！
