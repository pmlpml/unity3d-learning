---
layout: default
title: 方法扩展、Lambda 表达式
---

# 附录 X3-07、方法扩展、Lambda 表达式
{:.no_toc}

* 目录
{:toc}

## 1、类方法的扩展

### 1.1 初识类扩展

你可能觉得 C# 的  [Random](http://msdn.microsoft.com/zh-cn/library/system.random(v=VS.100).aspx) 类提供的方法不够用。如果想提供一些特殊随机数产生方法，你可以用以下方法扩展它：

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class extend_method_test{
        //This is Extened Method, The first parameter beging with (this Type name, args)
        public static bool NextBool(this System.Random random)
        {
                return random.NextDouble() > 0.5;
        }
}

public class NewBehaviourScript : MonoBehaviour {
        // Use this for initialization
        void Start () {
                System.Random rand = new System.Random();
                print (rand.NextBool ());
        }

        // Update is called once per frame
        void Update () {

        }
}
```

![](images/drf/info.png) 扩展方法必须是静态类中的静态方法，它们的第一个参数指定该方法作用于哪个类型，并且该参数以 this 修饰符为前缀。cs 编译器会自动将该方法编译到该类的方法表中。

* 将上述代码挂载到任意游戏对象上，就可以在 console 窗口看到输出。 

### 1.2 扩展方法的应用

当你需要对 C# 或 unity 的类做一些共性的扩展时，你仅需要将这些静态类的 cs 文件拖入项目编译。

一些常见的扩展方法应用。具体参考：[c# 扩展方法奇思妙用](http://www.cnblogs.com/ldp615/archive/2009/08/07/1541404.html)

![](images/drf/ichat.png) 使用 继承机制 与 扩展方法机制 各有哪些优缺点？

## 2、Lambda 表达式

### 2.1 Lambda 表达式案例
[lambda 表达式](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions) 是一个[匿名函数](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-methods)，在 C# 中使用它来创建 [delegates](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates) 或 [expression tree](http://msdn.microsoft.com/library/fb1d3ed8-d5b0-4211-a71f-dd271529294b) 类型。通过使用 lambda 表达式，可以编写可作为参数传递或作为函数调用的值返回的本地函数。Lambda 表达式对编写 LINQ 查询表达式特别有用。

要创建一个lambda表达式，可以在lambda运算符左侧指定输入参数（如果有的话）`=>`，然后将表达式或语句块放在另一侧。例如，lambda 表达式 `x => x * x` 指定一个已命名的参数 x 并返回 x 平方值。您可以将此表达式分配给委托类型，如以下示例所示：

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate int del(int i); //define delegate type

public class LambdaTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		del myDelegate = x => x * x;  //define anonymous function
		int j = myDelegate(5); //j = 25
		print (j);
	}
}
```

### 2.2 Lambda 表达式语法

**1、表达式 Lambdas**

语法

```
(input-parameters) => expression
```

例如：

```cs
(x, y) => x == y
```

**2、语句 Lambdas**

语法

```
(input-parameters) => { statement; }
```

例如：

```cs
delegate void TestDelegate(string s);

TestDelegate del = n => { string s = n + " World"; 
                          Console.WriteLine(s); };
```

**通用代理与泛型**

每次都定义代理多麻烦！ 微软定义了 `Func` 和 `Action` 及其[泛型代理](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates)，例如：

```cs
public delegate void Action<in T1, in T2>(
	T1 arg1,
	T2 arg2
)
```

这样，一个简单的三元匿名函数可以表达为：

```cs
  Action<int, string, bool> sendToLog = 
    (value, description, doLog) => 
        {
            if (doLog) Debug.Log("Logging out " 
            + value + " and " 
            + description); 
        };
```

![](images/drf/ichat.png) 函数回调 和 接口回调 的区别与联系？它们的适用场景？

更多参考微软手册 [Anonymous Functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions)


## 3、DoTween Unity 引擎的实现原理

### 3.1 DoTween 简介

[Dotween](http://dotween.demigiant.com/) 是 Unity 2D 方法使用的运动引擎，用于动画编程。

* 请进入官方网站 [Dotween](http://dotween.demigiant.com/)

它通过对 Unity 类扩展，实现了如下功能，官方实例：

```cs
// Move a transform to position 1,2,3 in 1 second
transform.DOMove(new Vector3(1,2,3), 1);
// Scale the Y of a transform to 3 in 1 second
transform.DOScaleY(3, 1);
// Pause a transform's tween
transform.DOPause();
```

现在的任务是运用学到的知识实现上述功能。好难？？？

### 3.2 DOMove 的实现思路

要实现类扩展，显然必须实现如下代码

```cs
public static class exciting_programming{

        public static Transform DoMove(this Transform transform, Vector3 target, float time)
        {
                //ToDo What?
                return transform;
        }
}
```

问题是如何实现 transform 的 update 呢？ 让我们来看一段代码：

```cs
using UnityEngine;
using System.Collections;

public static class exciting_programming{

        // Construct a MonoBehaviour coroutine method ！！！
        public static IEnumerator DoMove(this MonoBehaviour mono, Transform trans, Vector3 target, float time) {
                for (float f = 1f; f >= 0; f -= 0.1f) {
                        //just like call update()
                        Debug.Log (f);
                        yield return null;
                }
        }

        public static Transform DoMove(this Transform transform, Vector3 target, float time)
        {
                MonoBehaviour mono = transform.GetComponents<MonoBehaviour> () [0];
                mono.StartCoroutine (mono.DoMove(transform, target, time));
                return transform;
        }
}

public class NewBehaviourScript : MonoBehaviour {
        // Use this for initialization
        void Start () {
                transform.DoMove (new Vector3 (0, 0, 0), 1.0f);
        }
}
```

神奇的 coroutine 啊，程序竟然正确打印出 10 个时间了， 请解释上述代码！

### 3.3 DOMove 的实现代码

```cs
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class exciting_programming{

	public static IEnumerator DoMove(this MonoBehaviour mono, Transform trans, Vector3 target, float time, Action callback) {
		Vector3 distance = target - trans.position;
		for (float f = time; f >= 0.0f; f -= Time.deltaTime) {
			//just like call update()
			trans.Translate(distance * Time.deltaTime);
			//Debug.Log (Time.deltaTime);
			yield return null;
		};
		callback ();
	}

	public static Transform DoMove(this Transform transform, Vector3 target, float time)
	{
		MonoBehaviour mono = transform.GetComponents<MonoBehaviour> () [0];
		mono.StartCoroutine (mono.DoMove(transform, target, time, () => {
			MonoBehaviour.print("end of moving it!");
		}));
		return transform;
	}
}

public class DoMoveIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.DoMove (new Vector3 (1.0f, 1.0f, 1.0f), 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
```

这个程序非常不错，使用了 **方法扩展、协程、lambda 表达式** 等技术。既然运动可以表达为协程，那么一个物体的运动如何管理起来？如果你做到了这一点，iTweent 的实现不是菜吗？

不知不觉间，你已拥有了做这样牛叉组件的能力，是不是有所感悟！




