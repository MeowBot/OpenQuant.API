OpenQuant.API加强版
===================

此OpenQuant.API.dll是由ILSpy反编译后，经过部分修改，用Visual Studio重新编译而成。

## Features

1. 增加Bar constructor：`Bar(DateTime dateTime, double open, double high, double low, double close, long volume, long openInt, long size)`。

## Developer's Guide

### Easy Mode

Option 1: git clone后，在前人修改的基础上继续修改；

Option 2: git clone后，git checkout fresh，可在一个未经修改且可编译的OpenQuant.API上进行修改。

### Hard Mode

使用ILSpy重新反编译OpenQuant.API.dll，参见[OpenQuant.API.dll反编译教程](https://github.com/whenov/OpenQuant.API/wiki/Home)，完成教程后的工程应与fresh tag中的代码完全一致。
