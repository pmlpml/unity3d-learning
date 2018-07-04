---
layout: default
title: 集成脚本引擎
---

# 第十一章、集成脚本引擎
{:.no_toc}

> **_Don't let the noise of other's opinions drown out your own inner voice. And most important, have the courage to follow your heart and intuition._**  
>   
> --- Steve Jobs, Stanford Report, June 14, 2005

* 目录
{:toc}

## 课程内容与资源

![](images/game-architecture-script.png)

**1、资源下载**

![](images/drf/open_alt.png) [sLua](https://github.com/pangweiwei/slua)

**本节课内容属于游戏高级技术。如果你不打算从事游戏行业，了解即可**

_预计时间：6 * 45 min_


## 1、脚本引擎技术简介

### 1.1 什么是脚本？

在计算机领域，脚本又称动态脚本（Dynamic Scprits），一般特指解释执行语言，如 JavaScript, Python，perl，shell 等，脚本语言缩短了传统的编写-编译-链接-运行（edit-compile-link-run）过程，支持交互式编程，特别合适批任务处理、交互式命令控制或数据处理、小规模程序快速编程。

脚本语言通常都有简单、易学、易用的特性，是为非计算机专业人士定制 **领域特定语言（Domain Specific Languages）** 的利器。例如，著名的 Matlab、R 就是科学计算领域专用语言，它获得了计算领域研究人员、工程师的广泛认可。

### 1.2 游戏引擎为什么要嵌入 Lua？

简单说是 Lua 是一种通用的脚本语言，语法相对简单。 它有一个 c 语言编写的小巧的解释程序，这个程序很容易嵌入宿主（HOST）应用，并能够与宿主程序 **互操作（interoperation）**。所谓互操作，即宿主程序能调用 Lua 写的函数，反之 Lua 程序中也能调用宿主的函数。例如，微信小程序，就是在微信应用中嵌入一个 ECMAScript 的引擎，如 Google V8 或 JavaScriptCore （浏览器内核），然后在微信中开发一组共微信小程序调用的函数访问手机设备与微信内部资源。微信小程序就是脚本，微信应用就是 HOST。因此，微信小程序就是扩展微信应用的定制语言。

Lua，一种简单、高效的语言，一直是各类游戏引擎钟爱的嵌入语言，在移动设备上也有不错的表现，如 cocos2d 官方脚本集成就是 Lua。例如，与 Python 核心代码相比，Python 是 17 万行代码，而 Lua 是 2.4 万行。当然，小也是有代价的，就是没有丰富的语言特性，强大的基础函数库。通过嵌入 Lua ，游戏应用就可以被方便的扩展新功能。

**游戏嵌入脚本的作用**

* 方便角色行为逻辑设计。数据代码分离不是万能的，在游戏智能中，Agent 的规则推理机、决策树等方案不是普通设计师能理解的，使用简单的编程脚本，非计算机专业业务人员也能做一些简单游戏编程工作
* 开发一类游戏通用的引擎。开发者专注技术开发，将部分不通用、不太影响性能的游戏逻辑交给脚本实现，可大大提升同类游戏的开发效率（主程就解放了！）
* **热更新（HotFix）**。在线 **静默** 更新游戏逻辑

热更新，就是在线升级游戏，特别是手机游戏。受 IOS 等手机操作系统安全管理的制约，一个应用是没有权利修改任何可执行的代码权利，应用只可读写该应用下数据目录。这样，应用程序的更新就必须经过“App-store发布，用户下载，安装”这个流程，其中App-store发布审批一个环节就需要3-5天。脚本就是一个文本文件，如果问题代码在脚本中，直接从网上下载新版本，客户根本感受不到升级的过程。因此，“热更新”成为手机游戏的 **炙手可热** 的特征。 

### 1.3 Lua 脚本的能力与缺陷

在 Unity 中集成 Lua 引擎，一些 Lua 版本提供了完整游戏的开发能力，即一个游戏完全有 Lua 语言开发，如 SLua。

既然这么好，为什么不直接用 Lua 开发游戏？

* 慢。 假设 c 语言完成一个任务要 1 秒， C#，Java 等则需要 3 到 5 秒， Lua 等脚本语言再慢 10 倍 30 - 50 秒。 游戏是讲究 FPS 的啊！
* 调试难。 无类型语言很爽，但没有强大的静态语法检查，编译不能给你太多帮助。 大程序直接让你从内心崩溃！

典型集成 lua 的游戏产品：

* 大话西游2
* 魔兽世界Wow
* 剑侠情缘3

因此学习脚本引擎集成技术非常重要！

* 在知乎上搜 “游戏 Lua” 会有更多小伙伴讲授他们的经验和感受！  
* 如果你从此感兴于趣语言设计的秘密，请移步到《编译原理》课程。 Lua 将是该课程最佳实践教材！

## 2、Lua 入门

如果你有 c 语言和 javascript 基础（自我检查，会用函数闭包 [closures](https://en.wikipedia.org/wiki/Closure_(computer_programming)) 吗？）,建议你忽略本部分内容， 到维基百科了解 lua 语法即可。

### 2.1 lua world！

![](images/drf/movies.png) 操作 14-01，Lua入门练习：

进入 Lua 语言 [在线执行器](http://www.lua.org/demo.html)

输入 `print ("hello world!")` 然后按 run 按钮


### 2.2 lua 概览

建议课后阅读：

* [使用 Lua 编写可嵌入式脚本](http://www.ibm.com/developerworks/cn/linux/l-lua.html)
* [Lua (programming language)](https://en.wikipedia.org/wiki/Lua_(programming_language))

在执行器中执行维基百科文档中一些代码

* 条件、循环
* 函数与闭包
* 表、数组

Todo: 未来给案例

## 3、Unity 插件技术与 Lua 插件安装

### 3.1 Unity 插件（plugin）

Unity 支持两种插件，[官网文档](https://docs.unity3d.com/Manual/Plugins.html)：

* Managed: DotNet 平台，如 C# 编译的字节码（.dll）
* Native: 本地操作系统支持的动态库，这里特指 C/C++ 类 C 语言编译的动态库（.dll, .so）

### 3.2 Lua 动态库编译

如果如果你有 苹果 Mac 或 Linux PC， 可参照 SLua 的 make， 强力建议你自己 make 各个平台的库。

### 3.3 Lua 插件安装 

![](images/drf/movies.png) 操作 14-02，插件部署练习：

SLua 已编译的版本是 5.1.5，

1、下载 sLua 解压。主要目的是免去各平台下编译的烦恼，以及一些可供学习的原代码  
2、创建一个新项目 lua  
3、在 Assets 下创建目录 Plugins **注意大小写**！  

注意：各平台插件原生代码默认目录 [Plugin Inspector](https://docs.unity3d.com/Manual/PluginInspector.html) Setting!

4、加载平台本地动态库

将编译好的动态库（dll,so），从sLua对应目录拖入 Plugins。例如开发平台 64 位 window，则拖入 x64。

未来，你编译哪个平台，就加载哪个平台库。

5、加载 lua 与 c# 的接口库

在 Plugins 目录下建立目录 managed；

从 Slua -> Plugins -> Slua_Managed 中拖 LuaDLL.cs 和 LuaDLLWrapper.cs 进入 managed。导入 c 语言库，让 Unity 访问。

6、OK！ 运行，不应该出现任何错误。

## 4、Lua 虚拟机 与 Lua 栈

### 4.1 Lua 嵌入式 C API 浏览

浏览：[Lua 手册](http://www.lua.org/manual/5.3/) ！ 要点是最后的 Index, 选择一个 API

其中： [The Application Program Interface](http://www.lua.org/manual/5.3/manual.html#4)

### 4.2 Lua 虚拟机

**Lua 虚拟机** 即一个 Lua 程序的执行环境 或 沙箱。它由 `lua_newstate` 创建。

每个线程只能有一个 Lua 虚拟机。因此，仅有且只有第一个 Lua 虚拟机在 **程序主线程** 中，可以访问 Unity 的对象。

Unity 不支持除主线程以外的线程访问游戏对象，或与渲染相关的任何对象。当然，值类型、JsonUtility 通常是线程安全的

### 4.2 Lua 栈

每个虚拟机都有一个与应用程序交换数据的栈。这个栈默认有 **20 个元素**。应用程序必须保证栈的安全、正确使用。

Lua 每个 api 都有一个标志，[-o, +p, x] 表示出栈参数，入栈结果，是否返回异常。例如：:

```
lua_getglobal         [-0, +1, e]

int lua_getglobal (lua_State *L, const char *name);
Pushes onto the stack the value of the global name. Returns the type of that value
```

分别表示调用该 API ，没有元素出栈，有一个元素入栈，会有异常。

```
lua_tointeger          [-0, +0, –]

lua_Integer lua_tointeger (lua_State *L, int index);
Equivalent to lua_tointegerx with isnum equal to NULL.
```

api 中 index 参数表示数据在栈中位置，index 为负数，如 -1 表示栈顶，-2，-3 类推；  
index 为正数，表示位置， 如 1 是栈底，2，3 类推；  
lua_gettop 返回当前栈的高度；0 表示 空栈。
  
### 4.3 读 Lua 虚拟机的变量

![](images/drf/movies.png) 操作 14-03，读写 lua 变量练习：

```cs
using SLua;
using System;

public class my : MonoBehaviour {

        // Use this for initialization
        void Start () {
                IntPtr _L = LuaDLL.luaL_newstate ();    // create a lua VM
                LuaDLL.luaL_openlibs(_L);               // open lua libs

                LuaDLL.lua_dostring (_L,"num = 3");     // Excute a simple lua Script
                LuaDLL.lua_getglobal (_L, "num");       // push the lua var on the stack
                int i = LuaDLL.lua_tointeger (_L, -1);  // read return value
                LuaDLL.lua_pop(_L,1) ;                  // pop, your must maintain the stack carefully!!!
                Debug.logger.Log(i);
                //this.transform.position = new Vector3 (0, i, 0);

                LuaDLL.lua_close (_L);
        }
}
```

这个程序非常简单，第一步创建虚拟机；然后执行简单赋值，然后把变量结果通过栈传给应用；关闭虚拟机。

注意：错误操作特容易产生闪退，请及时保存程序！！

![](images/drf/ichat.png)  解释以下代码？栈有错误吗？

```
LuaDLL.lua_pushinteger (_L, 2);
LuaDLL.lua_setglobal (_L, "a");
LuaDLL.lua_pushinteger (_L, 3);
LuaDLL.lua_setglobal (_L, "b");
LuaDLL.lua_dostring (_L,"c = a+b");
LuaDLL.lua_getglobal (_L, "c");
Debug.logger.Log( LuaDLL.lua_tointeger (_L, -1) );
LuaDLL.lua_pop(_L,1) ;
```

`lua_setglobal` ，请翻译[手册描述](http://www.lua.org/manual/5.1/manual.html#lua_setglobal)，并解释 API 行为！

## 5、 HOST 与 Lua 互操作入门

![](images/drf/movies.png) 操作 14-04，相互调用函数练习：

该段代码第一部分是 HOST 调用 Luau 虚拟机中的 `foo (x,y)`，然后，Lua 程序调用 HOST 的 `dofile("luafile.lua")` 函数

```cs
using UnityEngine;
using System.Collections;

using System;
using UnityEngine.UI;
using LuaInterface;         // lua DLL C# 封装

public class Lua_func : MonoBehaviour {

        public GameObject text;

        // Use this for initialization
        void Start () {
                Text txt = text.GetComponent<Text> ();

                // Create Lua State
                IntPtr _L = LuaDLL.luaL_newstate ();
                LuaDLL.luaL_openlibs(_L);

                // define lua fuction
                String func = @"
function foo (x,y)
        return x+y
end
                ";
                LuaDLL.lua_dostring (_L,func);
                // call lua fuction
                LuaDLL.lua_getglobal (_L, "foo");               // push the lua function var on the stack
                LuaDLL.lua_pushnumber (_L, 6);                  // push paramters on the stack
                LuaDLL.lua_pushnumber (_L, 3);
                // http://www.lua.org/manual/5.1/manual.html#lua_call
                LuaDLL.lua_call (_L, 2, 1);                     //call foo with two parameter on Stack. [-(nargs+1), +nresults, e]
                // get result
                int i = LuaDLL.lua_tointeger (_L, -1);
                LuaDLL.lua_pop(_L,1) ;
                txt.text = i.ToString();

                // define cFunction in Lua machine，and then call it 
                LuaDLL.lua_pushcfunction (_L, dofile);  // set LuaCSFunction
                LuaDLL.lua_setglobal (_L, "dofile");    // assign to "dofile"
                LuaDLL.lua_dostring (_L, "dofile(\"tail.lua\")");       //call dofile(_L) in c#


                LuaDLL.lua_close (_L);
        }

        // lua dofile("luafile.lua") callback handler, must static
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        internal static int dofile(IntPtr L)
        {
                int n = LuaDLL.lua_gettop (L);          // number of arguments
                Debug.logger.Log (n);
                string fileName = LuaDLL.lua_tostring(L, 1); // index +/positive
                Debug.logger.Log (fileName);
                return 0;                                                       // number of results
        }
}
```

应用程序调用 Lua 定义的函数非常简单，将函数变量压入栈底，压入参数，然后 lua_call, 然后从栈顶取回返回值即可！

从 Lua 调用 c# 的函数就不那么简单了。

* 设置函数变量
* 调用 C 函数

[Lua 官方手册](http://www.lua.org/manual/5.1/manual.html#lua_CFunction) 给出了 CFunction 的通讯协议

```
typedef int (*lua_CFunction) (lua_State *L);
```

协议规定，Lua 函数参数按左到右，正方向压入栈。即 C 语言从 栈的 1，2，3 ... 位置读参数，API lua_gettop(L) 是参数的个数。 返回结果给 Lua 按接收顺序压入堆栈，返回值是参数的个数。

![](images/drf/ichat.png)  以下是 C 的函数，请翻译成 C# 并调用该函数

```c
static int foo (lua_State *L) {
  int n = lua_gettop(L);    /* number of arguments */
  lua_Number sum = 0;
        int i;
  for (i = 1; i <= n; i++) {
    if (!lua_isnumber(L, i)) {
      lua_pushstring(L, "incorrect argument");
      lua_error(L);
    }
   sum += lua_tonumber(L, i);
  }
  lua_pushnumber(L, sum/n);        /* first result */
  lua_pushnumber(L, sum);         /* second result */
  return 2;                   /* number of results */
}
```

* 如果 Lua 回调函数中存在异步加载、或继续调用 Lua 虚拟机？ 晕了，难以想象！
* 为什么必须使用 MonoPInvokeCallbackAttribute 呢？自己搜索！

## 6、结构、数组与数据交换

简单数据交换很方便，但是 C# 有 命名空间、类、结构、数字、字典等， Lua 的闭包函数与万能的 table、meta table， 它们是如何建立对应关系的呢？

为了了解数据交换，了解 lua[|T|S]_[push|to|is][*] 系列函数是必要的。 例如： lua_pushnumber 将 c 语言 double 压入栈成为 lua 认识的 number。 Lua 常见类型：boolean，number，string，nil 都可以处理。

**1、Lua 表**

如果你熟悉 javascript , lua 表和 javascript 表概念是没有区别的。javascript 每个实例有一个根表 window 而 Lua 是 _G 罢了。

例如 `window.x = 3`、`x = 3` 与 `window["x"]=3` 都是同样语义。

表就是一个 key-value 对集合的数据结构（字典）。表用 key 索引访问，索引一般是字符串或整数。虽然可以号称任意对象做索引，似乎也没有必要的。

![](images/drf/movies.png) 操作 14-04，复杂数据练习：

```lua
point = { x = 10, y = 20 }   -- Create new table
print(point["x"])            -- Prints 10
print(point.x)               -- Has exactly the same meaning as line above. The easier-to-read
                             --     dot notation is just syntactic sugar.
```

其中，`{...}` 表示表，是一个字典。dot 符号称为“语法糖”，让人类读起来舒服点。 让案例再复杂点:

```lua
point = { x = 10, y = 20 }
point[1] = "string1"
point[2] = "string2"
point[5] = "string5"
point[-1] = nil
point[point] = { x = 30, y = 40 }

print(point[2],point["x"],#point,point[3],point,point[point].x)
```

输出是:

```
string2 10      2       nil     table: 0x15f1f10        30
```

其中，# 操作符是计算数组的大小。 为什么不是 5 ？ 如何知道 point 中有什么 ？

```lua
for i,v in pairs(point) do
    if (type(i) ~= "table") then print (i.." = "..v) end
end
```

其中 `..` 表示字符 cat 操作；pairs 是内置迭代函数。 其实，这样赋值

```lua
point = {"string1","string2",nil,x = 10, y = 20,nil,"string5" }
```

输出也一样。

**2、结构（记录）、数组的交换**

Lua 应用程序 API 提供以下函数满足交换的要求。因为栈就只有 20 个单元，不可能把所有数据压上。数据处理过程如下:

假设栈内 index 位置元素是一个表（指针指向表）, 常用 API 有 lua_getglobal, lua_createtable；判断 lua_istable
读表的方法 lua_getTable, 写表就是 lua_settable
下边的代码就是我们读一个 points 数组到 c#

```cs
void Start () {
        // Create Lua State
        IntPtr _L = LuaDLL.luaL_newstate ();
        LuaDLL.luaL_openlibs(_L);

        //read vector[]
        String luaStr = @"_g = { {x=1,y=2},{x=3,y=4},{x=5,y=6} }";
        LuaDLL.lua_dostring (_L, luaStr);
        LuaDLL.lua_getglobal (_L, "_g");
        int index = LuaDLL.lua_gettop (_L);
        Debug.logger.Log ("index = " + index.ToString ());
        for (int i = 0;  i < 3; i++) {
                LuaDLL.lua_pushinteger (_L, i+1);               // index at 1 in lua
                LuaDLL.lua_gettable (_L, index);                // [-1, +1, e]
                int vind = LuaDLL.lua_gettop (_L);
                Debug.logger.Log ("vec index = " + vind.ToString ());
                LuaDLL.lua_pushstring (_L, "x");
                LuaDLL.lua_gettable (_L, vind);
                v2 [i].x = (float)LuaDLL.lua_tonumber (_L, -1);
                LuaDLL.lua_pushstring (_L, "y");
                LuaDLL.lua_gettable (_L, vind);
                v2 [i].y = (float)LuaDLL.lua_tonumber (_L, -1);
                Debug.logger.Log ("vec y = " + v2[i].y.ToString ());
                LuaDLL.lua_pop (_L, 3);                                 // why pop(3)?
        }
        LuaDLL.lua_pop (_L, 1);

        LuaDLL.lua_close (_L);
}
```

![](images/drf/ichat.png) 写一段程序，将一个 Vecter3 写到 Lua 中。

## 7、C# 函数与 C 函数

Lua 只有 C 接口，没有 C#。那么 lua_pushcfunction 在 C# 中如何实现呢？ 让我们分析 luaDLL.cs 原代码：

```cs
public static void lua_pushcfunction(IntPtr luaState, LuaCSFunction function)
{
    IntPtr fn = Marshal.GetFunctionPointerForDelegate(function);
    lua_pushcclosure(luaState, fn, 0);
}

[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
public static extern void lua_pushcclosure(IntPtr l, IntPtr f, int nup);
```

Marshal 类解包得到非托管的函数指针。MSDN 描述是“提供了一个方法集合，这些方法用于分配非托管内存、复制非托管内存块、将托管类型转换为非托管类型，此外还提供了在与非托管代码交互时使用的其他杂项方法” [] 。 可见，当我们享受托管带来的编程便利时，似乎忘记了底层关键技术，然而，要让 Lua 与 Unity 无缝交互，你需要知道语言的执行机理、编译技术、复杂的指针转换 ...

![](images/drf/ichat.png) C# 有没有闭包？...

## 8、Lua 集成技术小结

以上几乎描述了 Lua 与 C# 交互的所有技术。是吗？...

如果联想到 c# 的扩展函数，每个对象都可以用静态函数访问的啊。 难点是如何在 C# 那么多类和函数，如何包装。 Lua 端如何保持 C# 的习惯。

其实，好早就有人做好了这一切。luanet.dll [工具](http://www.cnblogs.com/sifenkesi/p/3901831.html)使用反射技术，实现了 C# 与 Lua 的无缝交互  。 以下是 Lua 与 Unity 交互一系列开源软件站点，如果你的游戏要顺利发布到各平台，读源代码也是必需的。下表是一些相关开源项目：

* LuaInterface (2004~2009) http://luaforge.net/projects/luainterface/
* Lua for Windows (2008~2010) http://luaforge.net/projects/luaforwindows/
* NLua (2009~2014) http://nlua.org/ 或 https://github.com/NLua/NLua
* ULua (2015~2016.3) http://ulua.org/ 或 https://github.com/topameng/tolua
* SLua (2015~2016) https://github.com/pangweiwei/slua

如何读源代码？首先要读早期的项目的，代码量小，可以让你了解核心理念与解决方案；后期的项目则逻辑严谨，代码量大。到 NLua 就是解决跨平台。 ULua 就是专心做 Unity 平台。 Slua 就是解决 iOS 平台不能动态编译、创建对象，把生成代码前置到编辑器中，比运行也比反射速度快。

本文仅讲述了脚本集成技术的基础，离实战有多大距离，但可以帮助你走好未来的路。

