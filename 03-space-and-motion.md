---
layout: default
title: 空间与运动
---

# 三、空间与运动
{:.no_toc}

>   
> **_I stumbled into by following my curiosity and intuition turned out to be priceless later on_**  
>   
> --- Steve Jobs, Stanford Report, June 14, 2005
>  

* 目录
{:toc}

_预计时间：2-3 * 45 min_

## 课程相关资源

[资源与代码下载](https://github.com/pmlpml/unity3d-learning/tree/motion)


## 1、游戏世界空间模型

### 1.1 游戏世界的设计维度（文化与艺术）

游戏世界是一个虚拟的世界、假想的世界、甚至其中部分是真实的世界。玩家控制部分游戏物体，按游戏世界或现实世界的规则交互，以达成设定目标。当虚拟世界与现实世界交融时，我们就称为增强现实（Augmented Reality）游戏。例如：我们在大富翁中采用现实股票行情，使用虚拟币在游戏中交易，更有利于玩家研究现实规则，做出有意义的决策；当现实商家优惠卷（Coopons）与《精灵宝可梦》这样的游戏机制相集合，就可以利用现实地图和玩家GPS位置，结合大数据技术推荐，产生实际的商用引流效果。

不管游戏世界是虚拟的或现实的，游戏世界中所有物体（游戏对象）都必须在特定的空间、时间下出现、变化、消失。因此，游戏设计必须定义空间、时间等。 Adams 在其教材中把游戏设计分为几个维度：

* 空间维度：
    - 自由度：2d 或 2d卷轴，3d, 2.5d(如 Aircraft)，4d（？）
    - 尺度：游戏世界的度量单位，如米、公里、光年。特别是其他物体与玩家对象的相对大小设计
    - 边界：玩家可以看到的地图与场景
* 时间维度
    - 例如：唐朝、宋朝；石器时代、铜器时代、铁器时代、火器时代、太空时代；
    - ...
* 环境维度
    - 时代与文化背景
    - 艺术风格与形式
    - 场景与物体搭配
* 情感维度
    - ...
* 道德维度
    - ...

![](images/ch03/ch03-space-design.png)

良好的空间设计，玩家体验的基础

![](images/drf/info.png) 如果你的这些维度感兴趣，请阅读游戏设计教材！

### 1.2 游戏世界空间模型（技术）

**世界坐标**：一个游戏或游戏场景的 **绝对坐标** 系统。每个游戏对象的位置、角度、比例的值都这个坐标系下是唯一的。

**对象坐标**：游戏对象相对父游戏对象的位置、角度、比例。又称为 **相对坐标**

**3D 空间**

坐标比较简单，典型 3D 正交坐标系统

* Z 轴：深度维度，前后方向。Z 越小越靠前
* Y 轴：高度维度，上下方向。Y 越大越高
* X 轴：水平维度，左右方向。

![](images/drf/library_bookmarked.png) **左手、右手坐标系统**

掌握此非常重要，相对坐标系中可快速确定位置

![](images/ch03/ch03-coordinate-system.png)

![](images/drf/help.png) Unity 是左手坐标系统？右手坐标系统？

**2D 空间**

2D 空间会复杂一些

* 离散 2D 坐标。瓦片空间，或网格空间，或棋盘空间都是一个概念。即使用整数完成游戏对象运动、碰撞等计算（早期计算机浮点性能很差哦），特别是蜂窝状六边形地图（你玩过的！）
* 连续 2D 坐标
* 混合坐标系统。看上去游戏对象连续运动，但内部计算是网格模型。例如，3D象棋

## 2、坐标变化与运动

游戏运动本质就是使用矩阵变换（平移、旋转、缩放）改变游戏对象的空间属性。

### 2.1 体验简单运动与叠加

![](images/drf/movies.png) 操作 03-01 ，简单运动练习：

```csharp
public class MoveLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.left * Time.deltaTime;
	}
}
```

* 先准备如上脚本 MoveLeft 
    - 这个代码每秒钟使得游戏对象向左移动一个单位
    - Vector3 是一个类，Vector3.left 是单位常数
    - Time 是离散引擎的核心类，Time.deltaTime 这个循环与上个循环之间的时间差
* 将代码拖放到任意游戏对象之上
* 运行游戏
* 观察，游戏对象左移了
* 终止游戏

![](images/drf/splash_green.png) 编程练习 03-02，复合运动：

编程要求与提示：

* 参照 MoveLeft 创建脚本 MoveUp
* 将脚本拖放到 MoveLeft 或它的子对象上
* 观察效果
* 修改 MoveLeft 代码如下

```csharp
public class MoveLeft : MonoBehaviour {

    public int speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += speed * Vector3.left * Time.deltaTime;
	}
}
```

* MoveLeft (Script) 多出一个 Speed 属性，修改它
* 运行并观察游戏；


### 2.2 Transform 部件

[TransForm 部件](https://docs.unity3d.com/ScriptReference/Transform.html) – **1、属性**

* 位置、欧拉角、比例、旋转
    - 世界坐标：position, eulerAngles, scale, rotation
    - 相对坐标：localposition, local…
* 对象空间轴（单位向量）
    - up, right, forward
* 空间依赖
    - parent, childCount

欧拉角（eulerAngles）：x、y和z角表示围绕z轴的旋转z度、围绕x轴的旋转x度和围绕y轴的旋转y度。

![](images/drf/movies.png) 操作 03-03 ，欧拉角练习：

* 在场景视图中放置一个长方体，如 scale = (4,1,1)
* 用左手握住 z 轴方向，修改 z 角度，如 45 度

转动（Rotation）：四元数（Quaternion）。 [Quaternion](https://docs.unity3d.com/ScriptReference/Quaternion.html) 使用向量（x,y,z,w）表示物体旋转，维基百科说它与欧拉角等价。所以：

* Quaternion.Euler(x,y,z) 可以得到四元数表示
* 一个四元数也可以使用方法 eulerAngles 的到欧拉角

反正你不要尝试修改四个元素的值，官方描述：`Don't modify this directly unless you know quaternions inside out.`

![](images/drf/help.png) 思考：四元素与三个元素的欧拉角等价，为什么要浪费空间用四个元素表示旋转？

**2、方法**

与直接修改游戏对象属性相比，TransForm 部件提供相关的方法，让程序猿编写更利于理解的运动程序。主要方法包括：

* 平移：[Translate](https://docs.unity3d.com/ScriptReference/Transform.Translate.html)
* 旋转：[Rotate](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html)
* 围绕：[RotateAround](https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html)
* 面向：[LookAt](https://docs.unity3d.com/ScriptReference/Transform.LookAt.html)

Unity 每个 API 都给出了丰富的案例解释这些方法，每个方法都有几个重载。

![](images/drf/library_bookmarked.png) API 设计者要以使用者易于理解、使用方便为目标，重载函数或方法是重要设计手段。

![](images/drf/splash_green.png) 编程练习 03-04，围绕运动：

编程要求与提示：

* 阅读 RotateAround 方法 API 案例
* 用一个球体表示太阳，一个球体表示地球
* 使用 RotateAround 让地球围绕太阳运动

### 2.3 向量与变换

如果程序员线性代数还过得去，一定会首选向量与变换控制运动，这毕竟是万能和高效的方法，虽然不易于理解。

**1、Vector3** 

Vector3是三维向量，是一个结构体。尽管 c# 把它化妆成对象模样，事实上我们仅需关心它的静态常数、成员与成员函数、静态方法即可

* 静态常数：zero, up, left, forward
* 成员与成员函数：x, y, z, normalized, magnitude
* 静态方法与算子:
    - Dot, Cross，Project，ProjectOnPlane
    - Distance，Angle，Normalize，Reflect
    - MoveTowards，RotateTowards
    - Lerp，Slerp

![](images/drf/splash_green.png) 编程练习 03-05，移动A到B运动：

编程要求与提示：

* 在设计器中放置两个游戏对象，A是一个球，B是空对象
* 阅读 Vector3.MoveTowards API 说明
* 编写一段程序让 A 使用 5 秒移动到 B 所在的位置

**2、Quaternion** 

Quaternion 是一个四维向量，是一个结构体。它表示了一个旋转变换，有着与矩阵运算类似的计算特性，能高效完成旋转变换。

**Quaternion 物理意义与基础编程**

物体在对象空间中旋转，事实上仅需要知道 **旋转轴单位向量** `e = (x,y,z)` **角度** `a`，如下图所示。 四元素 `q = ((x,y,z)sin(a/2),cos(a/2))` 。这样表示有许多好处。 建议参考维基百科。

![](images/ch03/ch03-quaternion.png)

【注意】 维基百科图使用的是右手坐标系！

我们先看一个特例，欧拉角（0，0，90）表示围绕 z 轴转 90度。 `q = ((0,0,1)sina(45),cos(45))` ，这样我们用四个数表示了旋转矩阵。因此，我们用一些代码检验我们的想法：

![](images/drf/movies.png) 操作 03-06 ，理解 Quaternion 练习：

* 先录入以下代码，注意了解使用的 Quaternion 方法含义：

```csharp
	void Start () {
		float anyF = 2.0f;
		Vector3 e = Vector3.forward * anyF;
		Quaternion q = Quaternion.AngleAxis (90, e);
		Debug.Log (q); //(0,0,0.7,0.7) expected

		Vector3 p1 = new Vector3 (1, 0, 0);
		// maxtrix left multify to a vetcor 
		Debug.Log (q * p1); // (0,1,0) expected

		Quaternion q1 = Quaternion.AngleAxis (45, e);
		// 90 rotate around z , and then 45
		Debug.Log (q1 * q * p1); // (0.7,.7,0,0) expected

        Quaternion q2 = Quaternion.Inverse (q);
		// Quaternion.identity
		Debug.Log (q2 * q); // (0.0, 0.0, 0.0, 1.0) expected
		Debug.Log (Quaternion.identity);
	}
```

你完全可以将 Quaternion 看成一个非常直观的旋转矩阵，利用矩阵乘向量得到旋转后的位置，矩阵连乘得到复合旋转！

四元素一个有以下特性：

* q 的长度是 1 
* q 就是旋转矩阵的一种表示，仅需要四个元数

因此，我们只要将左手握住物体的旋转轴，确定角度就可以方便的旋转了！！！它是旋转运动编程的第一选择。（与菜鸟区别的标志之一）

* 录入让物体按任意方向旋转的代码
* 挂入一个对象，运行它！

```csharp
public class RotateBeh : MonoBehaviour {

	public int speed = 20;
	public Vector3 e = Vector3.forward;

	// Update is called once per frame
	void Update () {
		Quaternion q = Quaternion.AngleAxis (speed * Time.deltaTime, e);
		transform.localRotation *= q; 
	}
}
```

* 在运行过程中修改速度和方向轴


![](images/drf/splash_green.png) 编程练习 03-07，编写 RotateAround 运动：

编程要求与提示：

* 在设计器中放置两个游戏对象，A是一个球，B是空对象
* 给定一个 speed 和 e
* 编写一段程序让 A 围绕 B 旋转

![](images/drf/help.png) 思考：四元素有哪些成员函数和静态方法是比较有用的？

### 2.4 游戏对象的空间组合




## 3、课堂实验（模拟太阳系）


## 4、面向对象的编程思考


## 5、小结

## 6、作业与练习

**c# 自学**

搜素 “c# 集合类型”， 了解以下类型的使用。 不知道使用，自己复习 C++ 模板库。

* List
* HashTable

不负责任的链接： http://blog.csdn.net/ceclar123/article/details/8655853

**作业内容**

1、简答并用程序验证

* 游戏对象运动的本质是什么？
* 请用三种方法以上方法，实现物体的抛物线运动。（如，修改Transform属性，使用向量Vector3的方法...）
* 写一个程序，实现一个完整的太阳系， 其他星球围绕太阳的转速必须不一样，且不在一个法平面上。

2、编程实践

* 阅读以下游戏脚本

> Priests and Devils
>
> Priests and Devils is a puzzle game in which you will help the Priests and Devils to cross the river within the time limit. There 
> are 3 priests and 3 devils at one side of the river. They all want to get to the other side of this river, but there is only one 
> boat and this boat can only carry two persons each time. And there must be one person steering the boat from one side to the other 
> side. In the flash game, you can click on them to move them and click the go button to move the boat to the other direction. If the 
> priests are out numbered by the devils on either side of the river, they get killed and the game is over. You can try it in many >
> ways. Keep all priests alive! Good luck!

程序需要满足的要求：

* play the game ( http://www.flash-game.net/game/2535/priests-and-devils.html )
* 列出游戏中提及的事物（Objects）
* 用表格列出玩家动作表（规则表），注意，动作越少越好
* 请将游戏中对象做成预制
* 在 GenGameObjects 中创建 长方形、正方形、球 及其色彩代表游戏中的对象。
* 使用 C# 集合类型 有效组织对象
* 整个游戏仅 主摄像机 和 一个 Empty 对象， **其他对象必须代码动态生成！！！** 。 整个游戏不许出现 Find 游戏对象， SendMessage 这类突破程序结构的 通讯耦合 语句。 **违背本条准则，不给分**
* 请使用课件架构图编程，**不接受非 MVC 结构程序**
* 注意细节，例如：船未靠岸，牧师与魔鬼上下船运动中，均不能接受用户事件！

**作业提交要求**

* 仅能用博客或在线文档提交作业，建议使用 Github 提交代码和作业。**不能使用docx、pdf等需要下载阅读的格式**
* deadline 问课程 TA

&nbsp;

[返回目录](./)  
