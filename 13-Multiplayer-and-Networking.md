---
layout: default
title: 多人游戏与网络
---

# 第 13 章 多人游戏与网络
{:.no_toc}

> **_万人操弓，共射一招，招无不中_**  
>   
> --- 【先秦】 《吕氏春秋》

* 目录
{:toc}

## 一、网络游戏

## 二、从零开始设置多人游戏项目

_注：以下内容来自 unity 5.5 手册 Setting up a Multiplayer Project from Scratch, 由谷歌预翻译。作者整理_

本部分介绍了设置简单多人游戏项目的步骤。这个循序渐进的过程是普适的，可以帮助理解 UNet 的一些基本概念。

**1、请创建一个新的空Unity项目**，开启网络游戏之旅。

**2、NetworkManager 设置**

第一步是在项目中创建 NetworkManager 对象：

* 从菜单 Game Object -\> Create Empty 添加一个新的空游戏对象。
* 在层次结构视图中选择它。
* 将对象重命名为“NetworkManager”，使用右键上下文菜单中或单击对象的名称并键入。
* 在对象的检查器窗口中，单击添加组件按钮
* 找到组件 Network -\> NetworkManager 并将其添加到对象。该组件管理游戏的网络状态。

![](images/ch13/UNetTut1.png)

* 找到组件 Network -\> NetworkManagerHUD 并将其添加到对象。该组件在您的游戏中提供了一个简单的用户界面来控制网络状态。

![](images/ch13/NetworkManagerRuntimeUI.png)

有关更多详细信息，请参阅使用 NetworkManager。

**3、设置玩家预制**

下一步是设置代表游戏中玩家的 Unity Prefab。默认情况下，NetworkManager通过克隆玩家预制来为每个玩家实例化一个对象。在这个例子中，玩家对象将是一个简单的立方体。

* 从菜单 Game Object -\> 3D Object -\> Cube 创建一个新的立方体

![](images/ch13/UNetTut2.png)

* 在层次视图中找到该立方体并选择它
* 将对象重命名为 “PlayerCube”
* 在对象的检查器窗口中，单击添加组件按钮
* 将组件 Network -\> NetworkIdentity 添加到对象。该组件用于标识服务器和客户端之间的对象。

![](images/ch13/UNetTut3.png)

* 将 NetworkIdentity 上的 “Local Player Authority” 复选框设置为 true。这将允许客户端控制玩家对象的移动

![](images/ch13/UNetTut4.png)

* 将立方体对象拖放到资源窗口中制作预制件。创建一个名为 “PlayerCube” 的预制件
* 从场景中删除 PlayerCube 对象 - 现在我们不需要它，我们有一个预制

详细信息 参考 Player Objects

**4、注册玩家预制**

一旦玩家预制被创建，它就必须在网络系统上注册。

* 在层次视图中找到 NetworkManager 对象并选择它
* 在 NetworkManager 组件面板打开 “Spawn Info” 折叠
* 找到 “Player Prefab” 位置
* 将 PlayerCube 预制件拖入 “Player Prefab” 位置

![](images/ch13/UNetTut5.png)

现在，请第一次保存该项目。从菜单 File -\> Save 保存项目。你也应该保存场景, 让我们称这个场景为 “offline” 场景。

**5、玩家运动（单人版）**

第一版游戏功能是移动玩家对象。在没有联网的情况下完成，因此它工作在单人模式下。

* 在资源视图中查找 PlayerCube 预制件。
* 点击Add Component 按钮并选择 “New Script”
* 为新的脚本名称输入名称 “PlayerMove”。一个新的脚本将被创建。
* 通过双击它在编辑器（如 Visual Studio）中打开这个新脚本
* 将这个简单的移动代码添加到脚本中：

```cs
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Update()
    {
        var x = Input.GetAxis("Horizontal")*0.1f;
        var z = Input.GetAxis("Vertical")*0.1f;

        transform.Translate(x, 0, z);
    }
}
```

这将钩住由箭头键或控制板控制的立方体。立方体只能在客户端上移动 - 它不是联网的。

再次保存该项目。

测试托管的游戏
点击播放按钮，在编辑器中进入播放模式。您应该看到NetworkManagerHUD的默认用户界面：


按“主持人”以游戏主持人的身份开始游戏。这将导致玩家对象被创建，并且HUD将改变以显示服务器处于活动状态。这个游戏是作为“主机”运行的 - 这是一个服务器和客户端在同一个过程中。

请参阅网络概念。

按下箭头键可以让玩家立方体对象四处移动。

通过在编辑器中按停止按钮退出播放模式。

测试玩家对客户的移动
使用菜单File - > Build Settings来打开Build Settings对话框。
按下“添加打开场景”按钮，将当前场景添加到版本

按“构建并运行”按钮创建构建。这会提示输入可执行文件的名称，输入一个名称，如“networkTest”
独立播放器将启动，并显示分辨率选择对话框。
选择“窗口”复选框和较低的分辨率，如640x480
独立播放器将启动并显示NetworkManager HUD。
从菜单中选择“主机”作为主机启动。应该创建一个玩家多维数据集
按箭头键稍微移动玩家立方体
切换回编辑器并关闭Build Settings对话框。
使用播放按钮进入播放模式
从NetworkManagerHUD用户界面中，选择“LAN Client”作为客户端连接到主机
应该有两个立方体，一个用于主机上的本地播放器，另一个用于该客户端的远程播放器
按箭头键移动立方体
这两个立方体都在移动 这是因为移动脚本不具有网络意识。
使播放器运动联网
关闭独立播放器
在编辑器中退出播放模式
打开PlayerMove脚本。
更新脚本以仅移动本地播放器
添加“使用UnityEngine.Networking”
将“MonoBehaviour”更改为“NetworkBehaviour”
在Update函数中添加一个“isLocalPlayer”检查，以便只有本地播放器处理输入
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal")*0.1f;
        var z = Input.GetAxis("Vertical")*0.1f;

        transform.Translate(x, 0, z);
    }
}
在资产视图中找到PlayerCube预制并选择
单击“添加组件”按钮并添加网络 - > NetworkTransform组件。该组件使对象在网络中同步它的位置。

再次保存该项目
测试多人游戏
重新构建并运行独立播放器并以主机身份启动
在编辑器中进入播放模式并作为客户端连接
玩家对象现在应该彼此独立移动，并且由其客户端上的本地玩家控制。
识别你的玩家
游戏中的立方体当前都是白色的，因此用户无法确定哪个立方体是立方体。为了识别玩家，我们将使本地玩家的立方体变红。

打开PlayerMove脚本
添加OnStartLocalPlayer函数的实现来更改播放器对象的颜色。
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
该功能仅在其客户端的本地播放器上调用。这将使用户看到他们的立方体为红色。OnStartLocalPlayer函数是初始化的好地方，仅用于本地播放器，例如配置摄像头和输入。

NetworkBehaviour基类还有其他有用的虚函数。见产卵。

构建并运行游戏
现在由本地玩家控制的立方体现在应该是红色的，而其他的仍然是白色的。
射击子弹（未联网）
多人游戏中的一个共同特点是让玩家发射子弹。本部分将非联网项目符号添加到示例中。下一部分添加了项目符号的网络连接。

创建一个球体游戏对象

将球体对象重命名为“Bullet”
将子弹的比例从1.o改为0.2
将项目符号拖到资产文件夹以制作项目符号的预制
从场景中删除项目符号对象
向子弹添加一个Rigidbody组件

将刚体上的“使用重力”复选框设置为false
更新PlayerMove脚本以启动项目符号：
为子弹预制添加公共插槽
在Update（）函数中添加输入处理
添加一个函数来发射子弹
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    public GameObject bulletPrefab;

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal")*0.1f;
        var z = Input.GetAxis("Vertical")*0.1f;

        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        // create the bullet object from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position - transform.forward,
            Quaternion.identity);

        // make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward*4;
        
        // make bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);        
    }
}
保存脚本并返回到编辑器
选择PlayerCube预制件并找到PlayerMove组件
在组件上找到bulletPrefab插槽
将公牛预制件拖入bulletPrefab插槽

进行构建，然后启动作为主机的独立播放器
在编辑器中进入播放模式并作为客户端连接
按空格键应该会导致一个子弹被创建并从玩家对象中发射
子弹不会在其他客户端上被触发，只有空格键被按下。
用网络拍摄子弹
本节在示例中将网络添加到项目符号中。

找到子弹预制件并选择它
将NetworkIdentity添加到项目符号预制
将NetworkTransform组件添加到项目符号预制
在项目符号预制的NetworkTransform组件上将发送速率设置为零。子弹在射击后不会改变方向或速度，因此不需要发送移动更新。

选择NetworkManager并打开“Spawn Info”折叠
用加号按钮添加一个新的spawn预制件
将Bullet预制件拖入新的spawn预制插槽

打开PlayerMove脚本
更新PlayerMove脚本以联络项目符号：
通过添加[Command]自定义属性和“Cmd”前缀，将Fire功能更改为联网命令
在子弹对象上使用Network.Spawn（）
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    public GameObject bulletPrefab;
    
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    [Command]
    void CmdFire()
    {
       // This [Command] code is run on the server!

       // create the bullet object locally
       var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position - transform.forward,
            Quaternion.identity);

       bullet.GetComponent<Rigidbody>().velocity = -transform.forward*4;
       
       // spawn the bullet on the clients
       NetworkServer.Spawn(bullet);
       
       // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
       Destroy(bullet, 2.0f);
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal")*0.1f;
        var z = Input.GetAxis("Vertical")*0.1f;

        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Command function is called from the client, but invoked on the server
            CmdFire();
        }
    }
}
此代码使用[Command]在服务器上触发项目符号。有关更多信息，请参阅联网操作。

进行构建，然后启动作为主机的独立播放器
在编辑器中进入播放模式并作为客户端连接
按下空格键应该让所有客户端上的正确玩家发射子弹
子弹碰撞
这增加了一个冲突处理程序，以便子弹在击中玩家立方体对象时消失。

找到子弹预制件并选择它
选择添加组件按钮并添加一个新脚本
调用新脚本“Bullet”
打开新脚本并添加碰撞处理程序，该程序在击中玩家对象时销毁子弹
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hitPlayer = hit.GetComponent<PlayerMove>();
        if (hitPlayer != null)
        {
            Destroy(gameObject);
        }
    }
}

现在当子弹击中玩家对象时，它将被销毁。当服务器上的子弹销毁时，由于它是由网络管理的衍生对象，因此它也将在客户端上销毁。

玩家状态（非联网健康）
与子弹有关的一个共同特征是玩家对象具有从完整值开始的“健康”属性，然后当玩家受到子弹击中伤害时减少。本节将非联网健康添加到玩家对象。

选择PlayerCube预制件
选择添加组件按钮并添加一个新脚本
调用剧本“战斗”
打开Combat脚本，添加健康变量和TakeDamage功能
using UnityEngine;

public class Combat : MonoBehaviour 
{
    public const int maxHealth = 100;
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead!");
        }
    }
}
子弹脚本需要更新以在命中时调用TakeDamage函数。*打开子弹脚本*在碰撞处理函数中添加一个来自Combat脚本的TakeDamage（）调用

using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hitPlayer = hit.GetComponent<PlayerMove>();
        if (hitPlayer != null)
        {
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(10);

            Destroy(gameObject);
        }
    }
}
当被子弹击中时，这会使玩家对象的健康状态下降。但是你不能在游戏中看到这种情况。我们需要添加一个简单的健康栏。*选择PlayerCube预制*选择添加组件按钮并添加一个名为HealthBar的新脚本*打开HealthBar脚本

这是很多使用旧GUI系统的代码。这对于网络来说并不相关，所以我们现在就使用它而没有解释。

using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
    GUIStyle healthStyle;
    GUIStyle backStyle;
    Combat combat;

    void Awake()
    {
        combat = GetComponent<Combat>();
    }

    void OnGUI()
    {
        InitStyles();

        // Draw a Health Bar

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        
        // draw health bar background
        GUI.color = Color.grey;
        GUI.backgroundColor = Color.grey;
        GUI.Box(new Rect(pos.x-26, Screen.height - pos.y + 20, Combat.maxHealth/2, 7), ".", backStyle);
        
        // draw health bar amount
        GUI.color = Color.green;
        GUI.backgroundColor = Color.green;
        GUI.Box(new Rect(pos.x-25, Screen.height - pos.y + 21, combat.health/2, 5), ".", healthStyle);
    }

    void InitStyles()
    {
        if( healthStyle == null )
        {
            healthStyle = new GUIStyle( GUI.skin.box );
            healthStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 1.0f ) );
        }

        if( backStyle == null )
        {
            backStyle = new GUIStyle( GUI.skin.box );
            backStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 0f, 0f, 1.0f ) );
        }
    }
    
    Texture2D MakeTex( int width, int height, Color col )
    {
        Color[] pix = new Color[width * height];
        for( int i = 0; i < pix.Length; ++i )
        {
            pix[ i ] = col;
        }
        Texture2D result = new Texture2D( width, height );
        result.SetPixels( pix );
        result.Apply();
        return result;
    }
}
保存该项目
构建并运行游戏并查看播放器对象上的健康栏
如果玩家现在射击另一个玩家，则该特定客户端的健康状况会下降，但其他客户端则不会。
玩家状态（网络健康）
现在到处都在应用健康变化 - 独立于客户和主机。这使得不同的玩家对健康看起来不同。运行状况应只应用于服务器，并将更改复制到客户端。我们称这个“服务器权威”为健康。

打开战斗脚本
将脚本更改为NetworkBehaviour
使健康成为[SyncVar]
将isServer检查添加到TakeDamage中，所以它只会应用在服务器上
有关SyncVars的更多信息，请参阅状态同步。

using UnityEngine;
using UnityEngine.Networking;

public class Combat :  NetworkBehaviour 
{
    public const int maxHealth = 100;

    [SyncVar]
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead!");
        }
    }
}

死亡和重生
目前，除了日志消息之外，当玩家的健康状况达到零时，目前没有任何事情发生。为了让游戏更具游戏性，当健康状况达到零时，玩家应该以完全健康的方式传送回起始位置。

打开战斗脚本
添加一个[ClientRpc]功能重新生成玩家对象。有关更多信息，请参阅联网操作。
当运行状况达到零时，调用服务器上的重新启动功能
using UnityEngine;
using UnityEngine.Networking;

public class Combat :  NetworkBehaviour 
{
    public const int maxHealth = 100;

    [SyncVar]
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        health -= amount;
        if (health <= 0)
        {
            health = maxHealth;

            // called on the server, will be invoked on the clients
            RpcRespawn();
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
            transform.position = Vector3.zero;
        }
    }
}
在这个游戏中，客户端控制玩家对象的位置 - 玩家对象在客户端具有“本地权限”。如果服务器只是将玩家的位置设置为开始位置，则客户端将覆盖该位置，因为客户端具有权限。为了避免这种情况，服务器通知拥有的客户端将播放器对象移动到开始位置。

构建并运行游戏
将玩家对象从开始位置移开
在一名玩家身上射击子弹，直到他们的健康状况达到零
玩家对象应该传送到开始位置。
非玩家对象
虽然玩家对象是在客户端连接到主机时产生的，但大多数游戏都存在游戏世界中存在的非玩家对象，例如敌人。在本节中添加了一个产卵者，它可以创建可以被射杀的非玩家对象。

从GameObject菜单中创建一个新的空游戏对象
将该对象重命名为“EnemySpawner”
选择EnemySpawner对象
选择添加组件按钮并将NetworkIdentity添加到该对象
在NetworkIdentity中单击“仅服务器”复选框。这使得产卵者不会被发送给客户。
选择Add Component按钮并创建一个名为“EnemySpawner”的新脚本
编辑新脚本
使其成为NetworkBehaviour
实现虚拟功能OnStartServer来创建敌人
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

    public GameObject enemyPrefab;
    public int numEnemies;

    public override void OnStartServer()
    {
        for (int i=0; i < numEnemies; i++)
        {
            var pos = new Vector3(
                Random.Range(-8.0f, 8.0f),
                0.2f,
                Random.Range(-8.0f, 8.0f)
                );

            var rotation = Quaternion.Euler( Random.Range(0,180), Random.Range(0,180), Random.Range(0,180));

            var enemy = (GameObject)Instantiate(enemyPrefab, pos, rotation);
            NetworkServer.Spawn(enemy);
        }
    }
}
现在创建一个敌人预制件：

从GameObject菜单中创建一个新的Capsule。
将对象重命名为“Enemy”
选择添加组件按钮将一个NetworkIdentity组件添加到敌人
选择添加组件按钮将NetworkTransform组件添加到敌人
将Enemy对象拖到资产视图中以创建预制件
应该有一个现在称为“敌人”的预制资产
从场景中删除Enemy对象
选择敌人预制
选择添加组件按钮并将战斗脚本添加到敌人
选择Add Component按钮并将HealthBar脚本添加到敌人
选择NetworkManager并在Spawn Info中添加一个新的可重复使用的预制件
将新的spawn预制设置为敌方预制
子弹脚本设置为仅适用于玩家。现在更新项目符号脚本以处理任何具有Combat脚本的对象：

打开项目符号脚本
更改碰撞检查以使用Combat而不是PlayerMove：
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hitCombat = hit.GetComponent<Combat>();
        if (hitCombat != null)
        {
            hitCombat.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
连接敌人物品的敌人：

选择EnemySpawner对象
找到EnemySpawner组件上的“Enemy”插槽
将敌人预制物拖入插槽
将numEnemies值设置为4
测试敌人：

构建并运行游戏
当作为主持人开始时，应该在随机位置创建四个敌人
玩家应该能够射击敌人，他们的健康状况应该下降
当客户加入时，他们应该看到处于相同位置的敌人，以及与服务器上相同的健康值
摧毁敌人
虽然敌人可以用子弹射击并且他们的健康状况下降，但是像玩家一样重生。当他们的健康达到零而不是重生时，敌人应该被毁灭。

打开战斗脚本
添加一个“destroyOnDeath”变量
当健康状况达到零时检查destroyOnDeath
using UnityEngine;
using UnityEngine.Networking;

public class Combat :  NetworkBehaviour 
{
    public const int maxHealth = 100;
    public bool destroyOnDeath;

    [SyncVar]
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        health -= amount;
        if (health <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                health = maxHealth;

                // called on the server, will be invoked on the clients
                RpcRespawn();
            }
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
            transform.position = Vector3.zero;
        }
    }
}

选择敌人预制
将敌人的destroyOnDeath复选框设置为true
现在当生命值为零时敌人将被摧毁，但玩家将重生。

派生玩家的位置
玩家目前全部出现在创建时的零点。这意味着它们可能在彼此之上。玩家应该在不同的地点产卵。NetworkStartPosition组件可用于执行此操作。

创建一个新的空GameObject

将该对象重命名为“Pos1”

选择添加组件按钮并添加NetworkStartPosition组件

将Pos1对象移动到位置（-3,0,0）

创建第二个空的GameObject

将对象重命名为“Pos2”

选择添加组件按钮并添加NetworkStartPosition组件

将Pos2对象移到位置（3,0,0）

找到NetworkManager并选择它。

打开“产卵信息”折页

将“玩家衍生方法”更改为“循环法”

构建并运行游戏

现在应该在Pos1和Pos2对象的位置创建播放器对象，而不是零。




http://blog.theknightsofunity.com/turn-based-multiplayer-game-gamesparks-unity-1/