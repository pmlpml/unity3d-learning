---
layout: default
title: 离散仿真引擎基础
---

# 二、离散仿真引擎基础
{:.no_toc}

>   
> **_You can't connect the dots looking forward; you can only connect them looking backwards_**  
>   
> --- Steve Jobs, Stanford Report, June 14, 2005
>  

* 目录
{:toc}

## 1、游戏引擎

### 1.1 游戏引擎概念与结构

> A _game engine_ is a software-development environment designed for people to build video games.  

根据这个定义，从 [Construct2](https://www.scirra.com/construct2) 到 [Unreal Engine](https://www.unrealengine.com/) 都是游戏引擎。之所以 Unreal Engine 才是你眼中引擎是因为 EPIC Game 能够提供电影艺术级别效果，一下就吸引了你的眼球。与指相比而 Construct2 等引擎尽管默默无闻，但也是无数游戏设计师、开发者的最爱。

![](images/ch02/ch02-game-engine-effects.png)

【注】游戏引擎产生了如此难以置信的精美而“真实”的场景画面，几乎每个人都梦想能开发这样的引擎！

简而言之，游戏引擎是一组游戏运行部件以及软件工具的集合。随着技术进步，多数现代游戏引擎都包含以下部件，游戏引擎架构如图所示：

![](images/game-architecture.png)

如上图所示，游戏引擎分为两个层次：

游戏内容层：一组工具管理游戏需要的数据  
游戏引擎层：一组游戏运行部件，支撑游戏的运行与人机交互

尽管不同厂家的引擎性能差别巨大，每个部件功能也不同，其基本原理和使用方法基本一致。特别的，现代游戏都是数据驱动的架构，即游戏代码工作量一般不太大，游戏的行为、规则主要由数据决定。

### 1.2 游戏引擎产生与分类

早期游戏引擎是在游戏开发过程产生的。例如：id TECH 制作了游戏 《德军总部3D》、《Doom 3》（毁灭战士）、《Quake》（雷神之锤）等大卖的 3D 游戏，同时也把 3D 游戏的核心部件以及相关工具卖给其他游戏公司或电影制作企业。比较著名的就是 [Quake engine](https://www.moddb.com/engines/quake-engine/downloads)，它的作者约翰·卡马克\* 是开源运动的支持者，你可以下载源代码与各种资源。

![](images/drf/info.png) 早期游戏引擎都是以动画与渲染为核心，并没有使用现代显卡技术。

【注】 约翰·卡马克，id TECH 联合创始人(John Carmack)。现在已经加入Oculus Rift 团队，并且担任首席技术官一职。

**PC与游戏机专业游戏引擎**

以下是一些商业引擎与代表作：

|引擎|代表作|
|---|---|
|虚幻/Unreal|《战争机器》|
|Cry Engine\*|《Crysis》|
|寒霜/Frostbite|《战地》|
|Infinity Ward|《使命召唤》|
|EGO|《尘埃2》|
|id TECH|《DOOM3》|
|Source|《半条命2》|
|X-Ray\*|《潜行者》|
|Havok Vision|《哥特王朝》|
|Quake/idTECH|《雷神之锤》|
|Chrome4\*|《狂野西部2》|
|MT framework|《生化危机5》|
|Gamebryo|《上古卷轴IV》|
|Jupiter EX|《 F.E.A.R》|

\* 顶级特效引擎，需要强大的 CPU 和 GPU（甚至超级计算）支持。

因为游戏引擎开源，具有实力的游戏公司一般都对外宣称拥有自己的游戏引擎。因此，要学好游戏开发，要点是强化游戏引擎知识，而不是简单的追随大厂如EPIC（Unreal）、EA（Frostbite）这些产品。

![](images/drf/library_bookmarked.png) 游戏引擎核心部件几乎 100% 由 c 和 c++ 实现。因此要进入游戏引擎开发的核心，c语言、数学、算法、计算机图形学等是基础。 如果要深入 AR/VR，SLAM 、计算机视觉与理解等技术是重要内容。因此游戏编程技术仅是游戏开发的一个方面，学好相关课程很重要。

**移动端游戏引擎**

手机端3D游戏引擎几乎是 Unity3D 一家独大。Unity Technologies 在PC、游戏机平台的游戏大厂比，难以竞争。就借助一款 [mono](https://github.com/mono/mono) 跨平台 .net 实现框架软件（类似java虚拟机），把它的游戏引擎部署到几乎任意的操作系统上，特别在手机平台上获得成功！

众多的开发者倒逼 Unity 成为一家专业提供游戏引擎与资源服务的公司。与传统游戏引擎比 Unity 3D 有着强大的开发工具和比较完善的服务社区，不仅是游戏入门学习的首选，也是 3D 手游开发的最佳工具之一。

Unity 的成功吸引了其他企业进入手游市场，其他包括：

* cocos 3d （cocos 2d 的扩展）
* Unreal

**面向游戏设计师的游戏引擎**

简单一些，就是几乎不用写代码（交互编程，可视化编程）的游戏引擎。常用于非计算机专业人员游戏入门、做游戏 demo 和 testing、编写 html5 小游戏等

* Construct2
* GameMaker: Studio
* GameMei


**网页平台（HTML5）游戏引擎**

具体说应该是 [WebGL](https://developer.mozilla.org/zh-CN/docs/Web/API/WebGL_API/Tutorial/Getting_started_with_WebGL) 开发的副产物，为展示新一代互联网图形基础设施而开发，并逐步走向流行。

* three.js  WebGL 官方效果展示项目
* babylon.js 目前发展较好的项目

**开源游戏引擎**

很多公司游戏引擎都是基于开源引擎而建，因此有必要了解它们

* Quake engine 系列
* OGRE
* Panda 3D
* Yake

一些公司，开源了部分基础代码以获得同行信任，如：

* Unity 3D
* Torque

## 2、游戏引擎核心-离散仿真

游戏就是模拟世界或构建虚拟世界。用计算机技术呈现现实或虚拟世界的动态场景，统称“离散仿真系统”

### 2.1 离散仿真的程序直观

这是一个简单的游戏世界，飞机打坦克的场景，如图所示：

![](images/ch02/ch02-horizen-motion.jpg)

为了呈现炮弹打击坦克的过程，

![](images/ch02/ch02-computing-motion.png)

需要不断计算炮弹的位置，并在屏幕上画出炮弹。当游戏的引擎每 1/60 秒计算出所有游戏对象的位置、形态，并在屏幕上画出来，我们就看到了如电影一般飞机打坦克的动态场景。

**游戏循环**

先看仿真系统底层运作的伪代码，在游戏引擎中称为游戏循环（Game Loop）：

```
initialize()
WHILE not end of game DO {
  updateGameObjects(t) //创建、删除、修改游戏对象
  drawGameObjects(t)   //绘制游戏对象
}
```

这么简单（难以置信）。是，微软 XNA 游戏引擎的基本框架就是这样，如图所示：

![](images/ch02/ch02-game-loop.jpg)

所有，XNA 游戏编程的模板如下：

```c
public class Game1 : Microsoft.Xna.Framework.Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {        
            base.Initialize();
        }

        protected override void LoadContent() {  
            spriteBatch = new SpriteBatch(GraphicsDevice); 
        }

        protected override void UnloadContent(){           
        }

        protected override void Update(GameTime gameTime)
        {           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
```

* GraphicsDeviceManager 图形设备管理器，用于访问图形设备的通道。
* GraphicsDevice 图形设备。
* Sprite 精灵，绘制在屏幕上的的2D或3D图像，比如游戏场景中的一个怪兽就是一个Sprite。
* SpriteBatch 它使用同样的方法来渲染一组Sprite对象。

既然游戏执行过程是固定的，但每步骤的具体内容是用户定义的，这就是“设计模式”教材上典型的模板方法模式设计！

尽管现代游戏引擎的游戏循环非常复杂，但作为开发者必须明白，所有复杂的代码均建立在这样简单的基础代码之上。

![](images/drf/library_bookmarked.png) 无论引擎怎么强大，其游戏循环一定是单线程的。即有仅有一个线程渲染画面，由于渲染过程中计算线程不能修改游戏对象状态，所以过多 CPU 很难被利用。 

### 2.2 离散仿真与离散事件仿真

“Discrete”是离散，在一个离散的系统中，我们总是能够找到一个时间点来标注系统的变化，比如研究对象进入系统和离开系统的时间点，进入队列和离开队列的时间点，开始加工和完成加工的时间点等等。这些时间点在时间轴上是离散而非连续的，而系统状态仅在离散的时间点上发生变化。

**离散仿真**

时间被分成为若干小的时间片，系统状态被这段时间内发生的系列活动而改变。称为基于活动的仿真（activity-based simulation）


















## X、作业与练习

**Unity 常用资源**

* Manual  https://docs.unity3d.com/Manual/index.html
* 中文参考 http://docs.manew.com/  、  http://wiki.ceeger.com/ceeger.php
* 官方案例 https://unity3d.com/cn/learn/tutorials
* UML 绘图工具 http://www.umlet.com/changes.htm

**作业内容**

1、简答题

* 解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。
* 下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）
* 编写一个代码，使用 debug 语句来验证 [MonoBehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) 基本行为或事件触发的条件
    - 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
    - 常用事件包括 OnGUI() OnDisable() OnEnable()
* 查找脚本手册，了解 [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html)，Transform，Component 对象
    - 分别翻译官方对三个对象的描述（Description）
    - 描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件
        - 本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。
        - 例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。
    - 用 UML 图描述 三者的关系（请使用 UMLet 14.1.1 stand-alone版本出图）

![workwork](images/ch02/ch02-homework.png)

* 整理相关学习资料，编写简单代码验证以下技术的实现：
    - 查找对象
    - 添加子对象
    - 遍历对象树
    - 清除所有子对象
* 资源预设（Prefabs）与 对象克隆 (clone)
    - 预设（Prefabs）有什么好处？
    - 预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？
    - 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象

2、 编程实践，小游戏

* 游戏内容： 井字棋 或 贷款计算器 或 简单计算器 等等
* 技术限制： 仅允许使用 **[IMGUI](https://docs.unity3d.com/Manual/GUIScriptingGuide.html)** 构建 UI
* 作业目的： 
    - 提升 debug 能力
    - 提升阅读 API 文档能力 

3、思考题【选作】

* 微软 XNA 引擎的 Game 对象屏蔽了游戏循环的细节，并使用一组虚方法让继承者完成它们，我们称这种设计为“模板方法模式”。
    - 为什么是“模板方法”模式而不是“策略模式”呢？ 
* 将游戏对象组成树型结构，每个节点都是游戏对象（或数）。
    - 尝试解释组合模式（Composite Pattern / 一种设计模式）。
    - 使用 BroadcastMessage() 方法，向子对象发送消息。你能写出 BroadcastMessage() 的伪代码吗?
* 一个游戏对象用许多部件描述不同方面的特征。我们设计坦克（Tank）游戏对象不是继承于GameObject对象，而是 GameObject 添加一组行为部件（Component）。
    - 这是什么设计模式？
    - 为什么不用继承设计特殊的游戏对象？

**作业提交要求**

* 仅能用博客或在线文档提交作业，建议使用 Github 提交代码和作业。**不能使用docx、pdf等需要下载阅读的格式**

&nbsp;

[返回目录](./)  

