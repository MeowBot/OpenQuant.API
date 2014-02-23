OpenQuant.API加强版
===================

此OpenQuant.API.dll是由ILSpy反编译后，经过部分修改，用Visual Studio重新编译而成。

针对OpenQuant 3.9.2版本（会在OpenQuant新版本出来后跟进合并，OpenQuant 2014除外）。

## Features

1. 增加Bar constructor：`Bar(DateTime dateTime, double open, double high, double low, double close, long volume, long openInt, long size)`

## Developer's Guide

### Easy Mode

git clone后，在前人修改的基础上继续修改。本repo会跟进合并最新版OpenQuant中的OpenQuant.API.dll。

### Hard Mode

使用ILSpy重新反编译OpenQuant.API.dll，参见[OpenQuant.API.dll反编译教程](https://github.com/whenov/OpenQuant.API/wiki/Home)。
