---
layout: default
title: 游戏对象与图形基础
---

# 四、游戏对象与图形基础
{:.no_toc}

>   
> **_It was beautiful, historical, artistically subtle in a way that science can't capture, and I found it fascinating_**  
>   
> --- Steve Jobs, Stanford Report, June 14, 2005
>  

* 目录
{:toc}

_预计时间：2-3 * 45 min_

## 1、构建游戏世界

### 1.1 游戏原型设计

艺术就是利用语言、声音、文字、绘画、眼神、呼吸、肢体等表达形式，创造游戏场景或情境，使人通过感知（看、听、嗅、触）得到某种审美的满足。因此，尽早的呈现游戏世界并与它互动，是感知游戏世界的第一步。例如：作家唐三描述了《斗罗大陆》，设计师就需要不断用绘图、手办等去描绘与改进这个世界。一方面，满足作者的目标，即“成神之路就是对世界法则的认知，每个人的有自己独特的成神之路，必须靠自己的努力”；另一方面，满足玩家的审美，特别是要逐步挖掘玩家内心深处的梦想或清洁 -- “修仙成神”。所以 Adams 强调，游戏过程就是玩家实现梦想之路。

Tracy Fullerton 在《游戏设计工坊》用原型设计描述这个步骤

> 原型是优秀游戏设计的核心。原型开发是为您的想法创建一个工作模型，允许您测试其可行性并对其进行改进。虽然游戏原型是可玩的，但通常只包含对美术作品、声音和功能的粗略近似。它们非常像草图，其目的是让你专注于一小部分游戏机制或功能，并观察它们是如何运作的。
>
> 许多第一次设计游戏的设计师宁愿投身其中并立即开始创造“真正的”游戏，而不是从原型开始。但是如果你投入时间，你就会发现没有什么比一个好的原型制作过程更有价值去提高游戏玩法了。当您在制作原型时，您不需要考虑如何完善它的外观或技术是否优化。您所需要担心的只是基本机制，如果这些机制能够维持游戏测试人员的兴趣，那么您就知道您的设计是可靠的。

![](images/ch04/ch04-physical-prototype.png)

游戏原型设计将设计师从编程或技术细节中解脱出来，聚焦于 MDA ：MDA的含义是指机制（Mechanics）、动态（Dynamics）和美学（Aesthetics）

判断一下你成为游戏设计师的概率：

* 你有多少手办？大概多少投入？

![](images/drf/info.png) 如果你对游戏世界设计感兴趣，请阅读游戏设计教材，Tracy Fullerton《游戏设计工坊》！

### 1.2 数字游戏原型设计

如果你有一支靠谱的设计与编程团队，他们不仅能用数字化手段支持游戏原型设计，而且能在短期内（3-7天）制作出游戏 Demo。甚至，编程团队可以创造出专用游戏设计引擎，支撑游戏的长期运行。

数据原型聚焦：

![](images/ch04/ch04-prototype-focus.png)

数字原型是可玩的，因此可以通过玩家测试，建立以数据为基础的分析与研究，持续改进游戏。

* 机制与动态：规则的复杂性、玩家成长曲线等基于数字的分析
* 运动：玩家的感觉分析
* 美学：玩家的试听分析
* 技术：渲染（shader）、VR、AI等

游戏设计工具：

* 平面设计工具，Photoshop...
* 3d 模型与动画设计工具，Maya...
* 游戏快速设计工具，Unity 3D, construct2...
* 专用游戏设计工具，...（游戏引擎都这么来的）

### 1.4 构建游戏 demo 的重要性

游戏开发是高风险（必须进入排名头部10~20%）、高投入（资源制作、市场开发与运维）的行业。

* 一个游戏故事，几幅游戏原画很难打动投资人
* 一个好题材，企业内部可能同时有几支团队并行开发 demo, 你必须成为最快最好的团队
* 你缺乏与题材合适的资源（形象设计、动画等）

Unity的资源和工具，帮助你构建你设想的游戏世界！







## 课程实践：Unity中使用多个相机

* 中文 [在Unity中使用多个相机 - 及其重要性](http://www.manew.com/thread-47076-1-1.html)
* 原文 [Using Multiple Unity Cameras – Why This May Be Important?](http://blog.theknightsofunity.com/using-multiple-unity-cameras-why-this-may-be-important/)

## 作业与练习

**自学资源**

* 用户手册 
    - [图形元素](https://docs.unity3d.com/Manual/GraphicsOverview.html)
    - [声音元素](https://docs.unity3d.com/Manual/AudioOverview.html)

* c# 结构体

不负责的连接： http://www.cnblogs.com/kissdodog/archive/2013/05/11/3072832.html

* C# 枚举与常数

不负责任的连接： http://www.cnblogs.com/kissdodog/archive/2013/01/16/2863515.html

**作业内容**

1、操作与总结

* 参考  Fantasy Skybox FREE 构建自己的游戏场景
* 写一个简单的总结，总结游戏对象的使用

2、编程实践

* 牧师与魔鬼 动作分离版

**作业提交要求**

* 仅能用博客或在线文档提交作业，建议使用 Github 提交代码和作业。**不能使用docx、pdf等需要下载阅读的格式**
* deadline 下周二 24 点前



