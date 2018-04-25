---
layout: default
title: 模型与动画
---

# 七、模型与动画
{:.no_toc}

&nbsp;

## 课程相关资源

1. [遗留模型 Garen](https://github.com/pmlpml/unity3d-learning/raw/ex-animatior/zips/Garen.zip)
2. [birds](https://github.com/pmlpml/unity3d-learning/raw/ex-animatior/zips/birds.zip)

## 作业与练习

1、智能巡逻兵（**选做**）

* 提交要求：**仅博客**
* 游戏设计要求：
    - 创建一个地图和若干巡逻兵(使用动画)；
    - 每个巡逻兵走一个3~5个边的凸多边型，位置数据是相对地址。即每次确定下一个目标位置，用自己当前位置为原点计算；
    - 巡逻兵碰撞到障碍物，则会自动选下一个点为目标；
    - 巡逻兵在设定范围内感知到玩家，会自动追击玩家；
    - 失去玩家目标后，继续巡逻；
    - 计分：玩家每次甩掉一个巡逻兵计一分，与巡逻兵碰撞游戏结束；
* 程序设计要求：
    - 必须使用订阅与发布模式传消息
        - subject：OnLostGoal
        - Publisher: ?
        - Subscriber: ?
    - 工厂模式生产巡逻兵
* 友善提示1：生成 3~5个边的凸多边型
    - 随机生成矩形
    - 在矩形每个边上随机找点，可得到 3 - 4 的凸多边型
    - 5 ?
* 友善提示2：参考以前博客，给出自己新玩法