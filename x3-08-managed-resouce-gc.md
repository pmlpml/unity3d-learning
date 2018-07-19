---
layout: default
title: 托管资源与垃圾回收
---

# 附录 X3-08、托管资源与垃圾回收
{:.no_toc}

* 目录
{:toc}


## 1、预备知识

### 1.1  程序的堆空间与栈空间

由C/C++编译的程序，其进程存储空间分为以下几个部分：

1. **栈（stack）区**：[栈](https://en.wikipedia.org/wiki/Stack_%28abstract_data_type%29#Compile_time_memory_management)是作为执行线程的临时空间预留的内存。调用函数时, 在堆栈顶部为局部变量和一些簿记数据预留块。当该函数返回时, 该块将变得不使用, 并且可以在下次调用函数时使用。堆栈始终在后进先出 (LIFO) 顺序中保留。最近保留的块总是下一个要释放的块。这使得跟踪栈变得非常简单;从堆栈中释放块（函数的参数值，局部变量的值）只不过是调整一个指针。

2、**堆（heap）区**：堆是预留给动态分配的内存。与堆栈不同, 不存在从堆中分配和释放块的强制模式。您可以随时分配块, 并在任何时候释放它。这使得在任何给定时间跟踪堆中的哪些部分被分配或释放是非常复杂的;有许多自定义堆分配器可用于为不同的使用模式调整堆性能。程序员必须正确的使用堆，即每次分配的块必须在使用完毕后释放，否则则会出现内存泄漏。

3、全局区（static）：也叫静态数据内存空间，存储全局变量和静态变量，全局变量和静态变量的存储是放一块的，初始化的全局变量和静态变量放一块区域，没有初始化的在相邻的另一块区域，程序结束后由系统释放。

4、文字常量区：常量字符串放在这里，程序结束后由系统释放。

5、程序代码区：存放函数体的二进制代码。

每个线程都得到一个堆栈，而应用程序通常只有一个堆(尽管不同类型的分配有多个堆并不少见)。

更多详细信息，建议参考 _[What and where are the stack and heap?](https://stackoverflow.com/questions/79923/what-and-where-are-the-stack-and-heap)_, 这些都是常见面试题：

* To what extent are they controlled by the OS or language runtime?
* What is their scope?
* What determines the size of each of them?
* What makes one faster?

 ### 1.2 对象、结构与数组的内存资源放置

 对象：
 
 * 用 new 实例化类，类的实例对象分配在堆（heap）上，并执行构造方法。直到析构方法被执行。
 * 变量是引用（ref）类型，用户只能通过变量指针访问堆上对象。
 * 对于 C++ ，必须使用 delete 关键字显式调用释放堆空间。

结构：

* 结构变量是值（value）类型，申明即分配 SizeOf(Type) 的空间
* 在参数或程序块中申明的结构，分配在栈（stack）上；结构数组或对象的属性则使用数组或对象分配的空间
* 结构变量的赋值，都是源值位置的空间  **Copy** 到目标位置
* 使用结构变量的指针，可以简化算法，优化性能。例如在堆上声明 SizeOf（Type） 的空间，用指针访问它。

数组：

* 通过 new 分配的数组空间一定在堆（heap）上
* 所有值类型（包括 struct）一定是分配 n * SizeOf（Type）的连续空间 
* 部分语言支持在栈上分配申明固定长度的数组
* new 显式分配的空间必须显式释放

### 1.3 垃圾回收

手动内存空间回收产生的常见问题包括：

* 悬挂指针：内存被回收，但遗留了指向该空间的指针。例如，在栈上定义了一个结构体，但其指针赋予了祖先函数的定义的指针，当结构体作用域消失则空间自动回收，再使用该指针，不可预见的 bug 出现了。
* 内存泄漏：堆上的内存空间，没有指针指向它，导致空间无法回收，产生内存泄漏的 bug 。例如，一个函数中 new 了对象或数组空间，但返回时，内存句柄（指针）自动回收了，但占用堆的空间没有释放，当多数调用该函数，则会耗尽堆空间。
* 多次释放空间：在程序多个位置释放同一空间的指针

为了帮助初级程序员回避这些复杂的 bug，从 Basic，Logo 等语言开始，人们尝试跟踪存储空间的使用，在编译期与运行期配合，实现自动空间回收的机制与算法。到 Java 语言出现，自动回收机制日益成熟，Java 虚拟机通过引用计数机制，自动管理内存。常见的垃圾回收策略包括：[跟踪、引用计数、Escape analysis](https://en.wikipedia.org/wiki/Garbage_collection_\(computer_science\)#Strategies)。

以 Java 垃圾回收（GC/Garbage Collection）为例，如果 `myObject = nil` 赋值后，如果 myObject 原来分配的对象不存在其他引用（对象不可达），垃圾回收管理程序会自动调用 `Object.finalize` 方法释放原对象引用的其他对象资源，但不包括操作系统的一些句柄，如文件、图像刷（需要用户程序自己关闭）等。因为 JDK 规范定义了一个对象的 `finalize` 能且仅能调用一次，因此不建议用户重写该方法，以避免影响垃圾回收机制正常工作。然后 GC 再检查是否能执行该对象的析构方法并回收该对象空间。更多垃圾回收信息 [Java Garbage Collection Basics](http://www.oracle.com/webfolder/technetwork/tutorials/obe/java/gc01/index.html)

## 2、C# 托管机制

C# 把内存资源分为两大类：

* 托管资源： .NET 可以自动进行回收的资源，主要是指托管堆上分配的内存资源。托管资源的回收工作由 .NET 运行库在合适调用垃圾回收器进行回收。
* 非托管资源： .NET 不知道如何回收的资源，最常见的一类非托管资源是包装操作系统资源的对象，例如文件，窗口，网络连接，数据库连接，画刷，图标等。

在.NET中，Object.Finalize()方法是无法重载的，编译器是根据类自动生成Object.Finalize()方法，用来释放托管的资源。

![](images/drf/exclamation.png) **注意，不能在析构函数中释放托管资源，因为析构函数是有垃圾回收器调用的，可能在析构函数调用之前，类包含的托管资源已经被回收了，从而导致无法预知的结果**

Microsoft为非托管资源的回收专门定义了一个接口：IDisposable，接口中只包含一个Dispose()方法。任何需要在对象析构之前释放非托管资源的类，都应该实现此接口。

## 3、非托管资源与互操作

为了与操作系统或其他应用互操作，不可避免需要使用指针。核心问题是，如果指针被其它应用保存，该指针返回时，而其指向的内容有可能已经被 .Net 自动回收了。这种情况下，要么指针指向内容被保存在非托管空间，要么强制不被垃圾回收器回收！

### 3.1 C# 互操作常见对象

* System.Intptr 结构。 MSDN 定义 `A platform-specific type that is used to represent a pointer or a handle.` 大概相当与 c 语言 `void *` 
* System.Runtime.InteropServices.Marshal 类。 MSDN 定义 `提供了一个方法集合，这些方法用于分配非托管内存、复制非托管内存块、将托管类型转换为非托管类型，此外还提供了在与非托管代码交互时使用的其他杂项方法。` 
* System.Runtime.InteropServices.GCHandle 结构。MSDN 定义 `Provides a way to access a managed object from unmanaged memory.`

### 3.2 值类型（struct）互操作

参见正文第十四章案例

### 3.3 对象（Object）互操作

参见正文第十四章案例








