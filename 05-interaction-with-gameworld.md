---
layout: default
title: 与游戏世界交互
---

# 五、与游戏世界交互
{:.no_toc}

## 课程相关资源

[资源与代码下载](https://github.com/pmlpml/unity3d-learning/tree/ex-interaction)

## 作业与练习

1、编写一个简单的鼠标打飞碟（Hit UFO）游戏

* 游戏内容要求：
    1. 游戏有 n 个 round，每个 round 都包括10 次 trial；
    2. 每个 trial 的飞碟的色彩、大小、发射位置、速度、角度、同时出现的个数都可能不同。它们由该 round 的 ruler 控制；
    3. 每个 trial 的飞碟有随机性，总体难度随 round 上升；
    4. 鼠标点中得分，得分规则按色彩、大小、速度不同计算，规则可自由设定。
* 游戏的要求：
    - 使用带缓存的工厂模式管理不同飞碟的生产与回收，该工厂必须是场景单实例的！具体实现见参考资源 Singleton 模板类
    - 近可能使用前面 MVC 结构实现人机交互与游戏模型分离

如果你的使用工厂有疑问，参考：[弹药和敌人：减少，重用和再利用](http://www.manew.com/thread-48481-1-1.html)

2、编写一个简单的自定义 Component （**选做**）

* 用自定义组件定义几种飞碟，做成预制
    - 参考官方脚本手册 https://docs.unity3d.com/ScriptReference/Editor.html
    - 实现自定义组件，编辑并赋予飞碟一些属性

如果你想了解跟多自定义插件或编辑器的话题，请参考：[Unity3d自定义一个编辑器组件/插件的简易教程](http://gad.qq.com/article/detail/22497)
