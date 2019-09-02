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

根据这个定义，从 [Construct2](https://www.scirra.com/construct2) 到 [Unreal Engine](https://www.unrealengine.com/) 都是游戏引擎。之所以 Unreal Engine 才算引擎是因为 EPIC Game 能够提供电影艺术级别效果，一下就吸引了你的眼球。与指相比而 Construct2 等引擎尽管默默无闻，但也是无数游戏设计师、开发者的最爱。

![](images/ch02/ch02-game-engine-effects.png)

【注】游戏引擎产生了如此难以置信的精美而“真实”的场景画面，几乎每个人都梦想能开发这样的引擎！

简而言之，游戏引擎是一组游戏运行部件以及软件工具的集合。随着技术进步，多数现代游戏引擎都包含以下部件，游戏引擎架构如图所示：

![](images/game-architecture.png)

如上图所示，游戏引擎分为两个层次：

游戏内容层：一组工具管理游戏需要的数据
游戏引擎层：一组游戏运行部件，支撑游戏的运行与人机交互

尽管不同厂家的引擎性能差别巨大，每个部件功能也不同，其基本原理和使用方法基本一致。特别的，现代游戏都是数据驱动的架构，即游戏代码工作量一般不太大，游戏的行为、规则主要由数据决定。

### 1.2 游戏引擎分类

早期游戏引擎是在游戏开发过程产生的。例如：id TECH 制作了游戏 《德军总部3D》、《Doom 3》（毁灭战士）、《Quake》（雷神之锤）等大卖的 3D 游戏，同时也把 3D 游戏的核心部件以及相关工具卖给其他游戏公司或电影制作企业。比较著名的就是 [Quake engine](https://www.moddb.com/engines/quake-engine/downloads)，它的作者约翰·卡马克\* 是开源运动的支持者，你可以下载源代码与各种资源。

![](images/drf/info.png) 早期游戏引擎都是以动画与渲染为核心，并没有使用现代显卡技术。

【注】 约翰·卡马克，id TECH 联合创始人(John Carmack)。现在已经加入Oculus Rift 团队，并且担任首席技术官一职。

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

游戏引擎核心部件几乎 100% 由 c 和 c++ 实现。因此要进入游戏引擎开发的核心，c语言、数学、算法、计算机图形学等是基础。 如果要深入 AR/VR，SLAM 、计算机视觉与理解等技术是重要内容。因此游戏编程技术仅是游戏开发的一个方面，学好相关课程很重要。



















## 作业与练习

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
* 尝试解释组合模式（Composite Pattern / 一种设计模式）。使用 BroadcastMessage() 方法
    - 向子对象发送消息

2、 编程实践，小游戏

* 游戏内容： 井字棋 或 贷款计算器 或 简单计算器 等等
* 技术限制： 仅允许使用 **[IMGUI](https://docs.unity3d.com/Manual/GUIScriptingGuide.html)** 构建 UI
* 作业目的： 
    - 提升 debug 能力
    - 提升阅读 API 文档能力 

**作业提交要求**

* 仅能用博客或在线文档提交作业，建议使用 Github 提交代码和作业。**不能使用docx、pdf等需要下载阅读的格式**

&nbsp;

[返回目录](./)  

