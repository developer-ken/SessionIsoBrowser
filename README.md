> 本帖最后由 develoepr_ken 于 2021-1-19 14:08 编辑

# **多会话隔离浏览器 SessionIsoBrowser**

一款可以在同一网站不同窗口同时登录多个不同账号的浏览器
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/b3fbc4fbe81248408ec25011c681279e)](https://www.codacy.com/gh/developer-ken/SessionIsoBrowser/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=developer-ken/SessionIsoBrowser&amp;utm_campaign=Badge_Grade)
---

#### ***有什么意义？***

手动刷课，特别是帮很多同学刷课的时候，可能需要登一个，刷完，退出，再登下一个。想要同时登陆几个账号的话就会需要装多个浏览器了，很麻烦。这款轻量级的浏览器，采用开源项目[CefSharp]()作为浏览器内核，并通过隔离上下文的方式实现浏览器隔离，这样就可以在不同窗口中同时登陆不同账号了，效率大大提升了呢。

---

#### **支持脚本吗？**

部分支持。

很遗憾，CefSharp无法正常加载浏览器扩展，这意味着我无法让您加载油猴插件。**但是**，我设法通过一些手段模拟了早期油猴的行为，并用另一些手段允许为新版油猴设计的插件在上述模拟环境下运行。浏览器内置了简单的脚本管理系统，可以安装全局脚本(对每个会话生效)，也可以安装本地脚本(对当前会话生效)。

因为对油猴的运作原理还不是很了解，我只能尽量模拟油猴的行为，达到近似相同的结果，而无法保证所有脚本都能正常运行。经验证，已支持 [超星网课助手(改)(查题可用)](https://bbs.tampermonkey.net.cn/thread-15-1-1.html) ，其它脚本还有待测试。如果遇到不支持的脚本或者相关问题可以回帖或者提交issue告诉我哦，会在以后的版本慢慢完善。

---

#### **在哪里下载啊？**

链接：[https://pan.baidu.com/s/1Cda0s6XxPxgUmZtS6ijZsw](https://pan.baidu.com/s/1Cda0s6XxPxgUmZtS6ijZsw)
提取码：eeqf

---

#### **你这这么简陋，不会是病毒吧？/ 我也会编程，有好点子，想帮你完善一下。**

项目开源，有疑问可以直接看源代码嘛  
想要帮我完善，欢迎提交Pr哦

---

#### **要怎么用呢？**

这个...说来话长...
