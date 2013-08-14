﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreManagement.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入正确的IP地址或者服务器")]
        public string InvalidIPAddressMsg {
            get {
                return ((string)(this["InvalidIPAddressMsg"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入正确的端口号")]
        public string InvalidIPPortMsg {
            get {
                return ((string)(this["InvalidIPPortMsg"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("登录成功，请在账本列表中选择对应账本。如果没有没有账本可供选择，请创建新的账本；如果没有选择账本则默认选择第一套账本；通过控制按钮可以创建或者删除账本。")]
        public string ABDescMessage {
            get {
                return ((string)(this["ABDescMessage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LandMen")]
        public string LMTABLE {
            get {
                return ((string)(this["LMTABLE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("master")]
        public string MSSQLSYSDB {
            get {
                return ((string)(this["MSSQLSYSDB"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dbo.sysobjects")]
        public string MSSQLSYSTABLE {
            get {
                return ((string)(this["MSSQLSYSTABLE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mysql")]
        public string MYSQLSYSDB {
            get {
                return ((string)(this["MYSQLSYSDB"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("information_schema.tables")]
        public string MYSQLSYSTABLE {
            get {
                return ((string)(this["MYSQLSYSTABLE"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入账本名称")]
        public string InvalidABNameMessage {
            get {
                return ((string)(this["InvalidABNameMessage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入数据库名称，注意只能是英文字符")]
        public string InvalidDBNameMessage {
            get {
                return ((string)(this["InvalidDBNameMessage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LMSP.sql")]
        public string LMSPFile {
            get {
                return ((string)(this["LMSPFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("90")]
        public int DftCompressRadio {
            get {
                return ((int)(this["DftCompressRadio"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.1.108")]
        public string ServerIP {
            get {
                return ((string)(this["ServerIP"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("7890")]
        public int SvrPort {
            get {
                return ((int)(this["SvrPort"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("32")]
        public int BufferSize {
            get {
                return ((int)(this["BufferSize"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int CmdLen {
            get {
                return ((int)(this["CmdLen"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int BufferPrefixLen {
            get {
                return ((int)(this["BufferPrefixLen"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("opshis.xml")]
        public string ApplicationHistory {
            get {
                return ((string)(this["ApplicationHistory"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ABSP.sql")]
        public string ABSPFile {
            get {
                return ((string)(this["ABSPFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("由于接下来操作需要拥有管理员级别的操作，所以请用管理员账户登陆")]
        public string AdminConfirmDescription {
            get {
                return ((string)(this["AdminConfirmDescription"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("用户名:")]
        public string UsernameInput {
            get {
                return ((string)(this["UsernameInput"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("密码  :")]
        public string PasswordInput {
            get {
                return ((string)(this["PasswordInput"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("记住登陆")]
        public string KeepHistoryInput {
            get {
                return ((string)(this["KeepHistoryInput"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("切换操作用户")]
        public string SysChangeUserDesc {
            get {
                return ((string)(this["SysChangeUserDesc"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入用户名")]
        public string UsernameInputHint {
            get {
                return ((string)(this["UsernameInputHint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入密码")]
        public string PasswordInputHint {
            get {
                return ((string)(this["PasswordInputHint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("用户名或者密码错误")]
        public string UsernamePasswordInputError {
            get {
                return ((string)(this["UsernamePasswordInputError"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("切换操作用户成功")]
        public string SysChangeUserSuccess {
            get {
                return ((string)(this["SysChangeUserSuccess"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("现有账本列表：")]
        public string SysChangeABDesc {
            get {
                return ((string)(this["SysChangeABDesc"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("获取账本列表出错")]
        public string SysChangeABInitError {
            get {
                return ((string)(this["SysChangeABInitError"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("切换账本失败")]
        public string SysChangeABError {
            get {
                return ((string)(this["SysChangeABError"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("切换账本成功")]
        public string SysChangeABSuccess {
            get {
                return ((string)(this["SysChangeABSuccess"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请选择账本")]
        public string ABInputHint {
            get {
                return ((string)(this["ABInputHint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("已经是当前账本")]
        public string SysChangeABSameDesc {
            get {
                return ((string)(this["SysChangeABSameDesc"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("原密码：")]
        public string SysChangePwdOldInput {
            get {
                return ((string)(this["SysChangePwdOldInput"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("新密码：")]
        public string SysChangePwdNewInput {
            get {
                return ((string)(this["SysChangePwdNewInput"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("确认新密码：")]
        public string SysChangePwdNewInput2 {
            get {
                return ((string)(this["SysChangePwdNewInput2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("新密码两次输入不正确")]
        public string SysChangePwdNotMatch {
            get {
                return ((string)(this["SysChangePwdNotMatch"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("原密码输入失败")]
        public string SysChangePwdIsNotValid {
            get {
                return ((string)(this["SysChangePwdIsNotValid"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("更新密码失败")]
        public string SysChangePwdError {
            get {
                return ((string)(this["SysChangePwdError"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("更新密码成功")]
        public string SysChangePwdSuccess {
            get {
                return ((string)(this["SysChangePwdSuccess"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入旧密码")]
        public string SysChangePwdOldInputHint {
            get {
                return ((string)(this["SysChangePwdOldInputHint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入新密码")]
        public string SysChangePwdNewInputHint {
            get {
                return ((string)(this["SysChangePwdNewInputHint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入确认新密码")]
        public string SysChangePwdNewInput2Hint {
            get {
                return ((string)(this["SysChangePwdNewInput2Hint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品编号")]
        public string GoodsInfoGoodsId {
            get {
                return ((string)(this["GoodsInfoGoodsId"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品全名")]
        public string GoodsInfoGoodsFullName {
            get {
                return ((string)(this["GoodsInfoGoodsFullName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品缩写")]
        public string GoodsInfoGoodsAbbrName {
            get {
                return ((string)(this["GoodsInfoGoodsAbbrName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("条形码格式")]
        public string GoodsInfoBarCodeFormat {
            get {
                return ((string)(this["GoodsInfoBarCodeFormat"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("条形码编号")]
        public string GoodsInfoBarCode {
            get {
                return ((string)(this["GoodsInfoBarCode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("过期日期")]
        public string GoodsInfoExpired {
            get {
                return ((string)(this["GoodsInfoExpired"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("季节")]
        public string GoodsInfoSeason {
            get {
                return ((string)(this["GoodsInfoSeason"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("品牌")]
        public string GoodsInfoBrand {
            get {
                return ((string)(this["GoodsInfoBrand"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("材料")]
        public string GoodsInfoStuff {
            get {
                return ((string)(this["GoodsInfoStuff"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品图片")]
        public string GoodsInfoPicture {
            get {
                return ((string)(this["GoodsInfoPicture"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品基本信息")]
        public string GoodsInfoBasicInfo {
            get {
                return ((string)(this["GoodsInfoBasicInfo"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("导入")]
        public string GoodsInfoPictureImport {
            get {
                return ((string)(this["GoodsInfoPictureImport"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("删除")]
        public string GoodsInfoPictureRemove {
            get {
                return ((string)(this["GoodsInfoPictureRemove"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品单位")]
        public string GoodsInfoUnit {
            get {
                return ((string)(this["GoodsInfoUnit"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("unspecified.gif")]
        public string GoodsInfoUnspecifiedPicture {
            get {
                return ((string)(this["GoodsInfoUnspecifiedPicture"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Pics")]
        public string PictureFolder {
            get {
                return ((string)(this["PictureFolder"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Unspecified.gif")]
        public string UnspecifiedPicture {
            get {
                return ((string)(this["UnspecifiedPicture"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("left.gif")]
        public string LeftArrowPicture {
            get {
                return ((string)(this["LeftArrowPicture"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("right.gif")]
        public string RightArrowPicture {
            get {
                return ((string)(this["RightArrowPicture"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("零售价1")]
        public string GoodsInfoPrice1 {
            get {
                return ((string)(this["GoodsInfoPrice1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("零售价2")]
        public string GoodsInfoPrice2 {
            get {
                return ((string)(this["GoodsInfoPrice2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("零售价3")]
        public string GoodsInfoPrice3 {
            get {
                return ((string)(this["GoodsInfoPrice3"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品信息")]
        public string GoodsViewerTitle {
            get {
                return ((string)(this["GoodsViewerTitle"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("创建商品分类")]
        public string FolderSettingCreateDesc {
            get {
                return ((string)(this["FolderSettingCreateDesc"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("修改商品分类")]
        public string FolderSettingModifyDesc {
            get {
                return ((string)(this["FolderSettingModifyDesc"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("商品分类名称")]
        public string FolderSettingName {
            get {
                return ((string)(this["FolderSettingName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("请输入商品分类")]
        public string FolderSettingEmptyName {
            get {
                return ((string)(this["FolderSettingEmptyName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("父分类不存在")]
        public string FolderSettingParentIdInexistenceErrorMessage {
            get {
                return ((string)(this["FolderSettingParentIdInexistenceErrorMessage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("同名分类已经存在")]
        public string FolderSettingSameFolderErrorMessage {
            get {
                return ((string)(this["FolderSettingSameFolderErrorMessage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("创建分类成功")]
        public string FolderSettingAddSuccess {
            get {
                return ((string)(this["FolderSettingAddSuccess"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("修改分类成功")]
        public string FolderSettingModifySuccess {
            get {
                return ((string)(this["FolderSettingModifySuccess"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("./Pics/Throbber.gif")]
        public string ThrobberImage {
            get {
                return ((string)(this["ThrobberImage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("获取条形码格式失败")]
        public string GetBarCodeFormatError {
            get {
                return ((string)(this["GetBarCodeFormatError"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("是否保存修改")]
        public string SaveModifyHint {
            get {
                return ((string)(this["SaveModifyHint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("警告")]
        public string WarningTitle {
            get {
                return ((string)(this["WarningTitle"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("提示")]
        public string InformationTitle {
            get {
                return ((string)(this["InformationTitle"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("错误")]
        public string ErrorTitle {
            get {
                return ((string)(this["ErrorTitle"]));
            }
            set {
                this["ErrorTitle"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("尺寸")]
        public string Size {
            get {
                return ((string)(this["Size"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("颜色")]
        public string Color {
            get {
                return ((string)(this["Color"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("获取颜色列表失败")]
        public string GetAllColorError {
            get {
                return ((string)(this["GetAllColorError"]));
            }
        }
    }
}