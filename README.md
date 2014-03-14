OpenQuant.API加强版
===================

此OpenQuant.API.dll是由ILSpy反编译后，经过部分修改，用Visual Studio重新编译而成。

随时跟进OpenQuant最新版本，OpenQuant 2014除外，x32/x64可通用。

## Features

* 增加Bar constructor：`Bar(DateTime dateTime, double open, double high, double low, double close, long volume, long openInt, long size)`

* 增加BarSeries的Crosses系重载函数：
    - `Cross Crosses(double level, Bar bar)`
    - `bool CrossesAbove(double level, Bar bar)`
    - `bool CrossesBelow(double level, Bar bar)`

* 为BarSeries和Indicator增加Implicit Conversion Operator，分别转换为BarSeries.Last.Close和Indicator.Last，支持如`indicator + bars * 0.001`等语句；

* 增加TimeSeries的加减乘除运算符重载，支持`timeseries + 42`或`42 + timeseries`运算，返回TimeSeries类型。

## Developer's Guide

### Easy Mode

git clone后，在前人修改的基础上继续修改。本repo会跟进合并最新版OpenQuant中的OpenQuant.API.dll。

### Hard Mode

使用ILSpy重新反编译OpenQuant.API.dll，参见[OpenQuant.API.dll反编译教程](https://github.com/whenov/OpenQuant.API/wiki/Home)。
