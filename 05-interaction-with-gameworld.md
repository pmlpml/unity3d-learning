---
layout: default
title: 与游戏世界交互
---

# 五、与游戏世界交互
{:.no_toc}

>   
> **_It freed me to enter one of the most creative periods of my life_**  
>   
> --- Steve Jobs, Stanford Report, June 14, 2005
>  

* 目录
{:toc}

_预计时间：2-3 * 45 min_

## 课程相关资源

[资源与代码下载](https://github.com/pmlpml/unity3d-learning/tree/ex-interaction)

## 1、游戏交互与创新

游戏交互是玩家体验的基础。这里 **交互模型** 定义为建立输入设备的输入与游戏世界中的对象行为之间的关系，以及游戏世界状态与玩家感知（视觉、听觉、触觉、嗅觉等之间的关系）。在科幻电影中，玩家通过脑电波驾驶与控制装备；在现实的游戏中，通常使用操纵杆控制游戏中玩家扮演的角色。

### 1.1 游戏交互模式设计

Adams 认为交互设计是用户体验的核心内容，游戏输入装备的功能和性能会影响玩家在游戏中的行为选择。Adams 从游戏设计角度给出了交互设计的要点。游戏典型的交互模型包括：

* 角色扮演模型。即玩家扮演游戏世界中的一个对象，并实现游戏操纵杆及其按钮的操作与游戏对象行为之间的映射。这样，玩家就可以通过一个或多个设备控制游戏对象。
* 多视角交互模型。即为游戏世界构建多个视图，每个视图反映不同观察视角或游戏的状态，使得玩家可以在不同视图中选择合适的方式（如菜单、软件工具等）与游戏世界交互。
* 团队交互模型。在社交类游戏中，通常有视图反映协同玩家状态，如队友列表等，玩家可通过广播、视频、聊天室、私聊等即时沟通渠道实现协作。
* 竞技交互模式。具备竞技模式一般需要支持更多的游戏设备，以满足发烧玩家的需要。使用 180 度屏幕、7 声道杜比立体声、游戏鼠标等的玩家，显然都是游戏公司争夺的 VIP。
* 桌面、移动交互模式。以大众客户为目标，通常是小游戏或商业游戏。

Adams 对交互模型中常见的设计问题做了一些总结：

* 视角
    - 3D 与 2D 的选择
    - 第一人称与第三人称的感知差异
    - 多摄像机与投影模型
* 视觉元素
    - 主视野
    - 反馈元素（如血条等表示游戏世界对象的状态）
    - 小地图
    - 化身肖像
    - 菜单与按钮
* 音频元素

![](images/drf/info.png) 如果你对游戏交互设计感兴趣，请阅读游戏设计教材，Adams《游戏设计基础》！

### 1.2 游戏创新方法

游戏创新存在比较明显的鄙视链现象。用专业输入装备玩游戏的鄙视用手机玩游戏、Unreal开发者鄙视Unity开发者，这些容易理解，创新也分等级就难以理解了。 [Quake engine](https://www.moddb.com/engines/quake-engine/downloads)的作者约翰·卡马克，为什么要加入 Oculus Rift 团队，并出任首席技术专家？

**1、游戏创新第一层：交互装备创新**

说到游戏交互装备创新，最厉害的参与者是 Apple、Microsoft、Nintendo、Sony，它们都是实力雄厚的大厂。在 AR/VR 与 物联网 时代 HTC、Oculus 以及其他厂商也积极融入其中。也许有一天，小米的各种 IoT 外设成为现代游戏元素的一部分。（**IoT 游戏？2019年的预言，未来会不会流行呢？**）

以 Nintendo 的《[口袋妖怪/精灵宝可梦](https://baike.sogou.com/v56171.htm?fromTitle=%E5%8F%A3%E8%A2%8B%E5%A6%96%E6%80%AA)》系列为例，第一代游戏掌机就配备的游戏；2006 年，任天堂发布了新一代游戏主机Wii，Wii配套的新款游戏手柄第一次将体感动作引入了游戏，体感装备出现后，用户们第一次发现原来除了传统的手柄按键控制之外，自己还可以直接用身体动作来控制屏幕上的游戏人物，《精灵宝可梦》出现了许多新玩法；2016年，《精灵宝可梦GO》更是现象级游戏，将现实地图与GPS位置引入游戏，预示 AR 游戏时代的到来。

Microsoft，首创带力反馈游戏手柄；人体识别体感装置 Kinect ；全息眼镜 HoloLens。这些装备改变了人机交互方式，游戏更好用于医疗、复杂环境的仿真与教学。

Apple 就不用说了。手机游戏几乎伴随智能手机成长。手机中许多传感器几乎就是为游戏而生。多点触摸、3d Touch，以及今天 Apple “奇丑无比” 的双肩屏（AR kit 需要这个传感器），哪个不瞄准游戏交互的制高点。

因此，运用现代交互与呈现技术是游戏创新的首选（仅对学生而言）。

**2、游戏创新第二层：机制创新**

通常游戏竞赛都是聚焦这个层面，具体包括：

* 新设备在新领域（医疗、公益、电商、社交）的应用
* 游戏与智能技术（语音交互、智能学习、各种识别… …）
* 新颖玩法（Flappy Bird、Temple Run … …）
* 题材创新（如挑战极限系列，史上最难….）

**3、游戏创新第三层：以客户为中心的创新**

对于商业公司挣钱才是第一要素。因此，他们更希望是较小的风险和较高的收益，或者是砸钱易出效果类型。例如：“吃鸡”类游戏很流行，大家都忙推这类游戏。同类游戏，大家 PK 什么呢？

* 细腻逼真的 3D 素材（比技术门槛和经费，如暴雪产品）
* 热门故事（通常与历史、热门电影、政治事件绑定）
* 满足各种脑残粉（如：开心消消乐、国内所有页游）

**4、创新选择**

**体验、体验、新体验！！！**

* 游戏题材：
    - 体育、教育、赛车、社交等题材最敏感
* 交互创新：
    - 触摸交互，重力交互，语音交互，体感交互
* AR/VR
    - 沉浸式体验技术，最热

游戏基本形式：

* 经济性驱动的游戏
    - 选择手机及其智能设备创新游戏
* 挑战性驱动的游戏
    - 必须包含，键盘
* 行为模式驱动的游戏
    - 碎片时间游戏


### 1.3 常见游戏输入设备

**1、经典“三宝”**

* 键盘（KeyBoard）
* 鼠标（Mouse）
* 游戏操纵杆（Joystick）

**2、手机游戏输入设备**

* 触摸屏（TouchPad）
* 重力/位置传感器（Gravity/Geo Sensor）
* 麦克风（Audio）
* 摄像头（AR）
    - 物体识别与跟踪（Tracking）
    - 3D 建模（SLAM）
* 手势/体态（Gesture/Posture）
* 蓝牙, NFC … … 包括可连接手机的各种智能设备

**3、IoT 与 其他设备**

* VR头盔
* Hololen
* 体感、Kinect
* 条码、激光等各种传感器 … …

## 2、Unity 输入处理

![](images/drf/advanced.png) 维护中的章节

### 2.1 输入信息处理基本模型

### 2.2 JoyStick – 虚拟轴与按键

```csharp
public class Joystick : MonoBehaviour {

	public float speedX = 10.0F;
	public float speedY = 10.0F;

	// Update is called once per frame
	void Update () {
		float translationY = Input.GetAxis("Vertical") * speedY;
		float translationX = Input.GetAxis("Horizontal") * speedX;
		translationY *= Time.deltaTime;
		translationX *= Time.deltaTime;
		//transform.Translate(0, translationY, 0);
		//transform.Translate(translationX, 0, 0);
		transform.Translate(translationX, translationY, 0);

		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Fired Pressed");
		}
	}
}
```


### 2.3 拾取游戏世界的对象

**光标拾取物体程序**

```csharp
public class PickupObject : MonoBehaviour {

	public GameObject cam;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Debug.Log ("Fired Pressed");
			Debug.Log (Input.mousePosition);

			Vector3 mp = Input.mousePosition; //get Screen Position

			//create ray, origin is camera, and direction to mousepoint
			Camera ca;
			if (cam != null ) ca = cam.GetComponent<Camera> (); 
			else ca = Camera.main;

			Ray ray = ca.ScreenPointToRay(Input.mousePosition);

			//Return the ray's hit
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				print (hit.transform.gameObject.name);
				if (hit.collider.gameObject.tag.Contains("Finish")) { //plane tag
					Debug.Log ("hit " + hit.collider.gameObject.name +"!" ); 
				}
				Destroy (hit.transform.gameObject);
			}
		}
	}
}
```

程序要点：

* mousePosition 是 Vector3 ，请不要修改 z 坐标
* 获取摄像机的 Camera 部件，构建 Ray
* Camera 部件支持正确生成世界坐标的射线
* Raycast 函数使用了变参（值参与变参），为什么 hit 必须用变参？
* 为了优化性能，Raycast 支持在特定层扫描对象 

**光标拾取多个物体程序**

```csharp
public class PickupMultiObjects : MonoBehaviour {

	public GameObject cam;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Debug.Log ("Fired Pressed");
			Debug.Log (Input.mousePosition);

			Vector3 mp = Input.mousePosition; //get Screen Position

			//create ray, origin is camera, and direction to mousepoint
			Camera ca;
			if (cam != null ) ca = cam.GetComponent<Camera> (); 
			else ca = Camera.main;

			Ray ray = ca.ScreenPointToRay(Input.mousePosition);

			//Return the ray's hits
			RaycastHit[] hits = Physics.RaycastAll (ray);

			foreach (RaycastHit hit in hits) {
				print (hit.transform.gameObject.name);
				if (hit.collider.gameObject.tag.Contains("Finish")) { //plane tag
					Debug.Log ("hit " + hit.collider.gameObject.name +"!" ); 
				}
				Destroy (hit.transform.gameObject);
			}
		}		
	}
}
```

**性能与优化**


## 3、面向对象的游戏编程

### 场景单实例

运用模板，可以为每个 MonoBehaviour子类 创建一个对象的实例。`Singleten<T>` 代码如图所示：

```csharp
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

	protected static T instance;

	public static T Instance {  
		get {  
			if (instance == null) { 
				instance = (T)FindObjectOfType (typeof(T));  
				if (instance == null) {  
					Debug.LogError ("An instance of " + typeof(T) +
					" is needed in the scene, but there is none.");  
				}  
			}  
			return instance;  
		}  
	}
}
```

场景单实例的使用很简单，你仅需要将 MonoBehaviour 子类对象挂载任何一个游戏对象上即可。

然后在任意位置使用代码 `Singleton<YourMonoType>.Instance` 获得该对象。

## 4、小结

## 5、作业与练习

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

