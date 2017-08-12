# native-image-compressor
Image compressing project using GDI+ by .NET. This was used to compress multi-files on you local computer at once. You can download the exe and dependency [this folder](https://github.com/muzavan/native-image-compressor/tree/master/bin/Debug) as zip and configure the `ImageCompressor.exe.config`.

# Configuration
Pretty straight-forward.

```XML
﻿<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,Log4net"/>
  </configSections>
  
  <startup> 
      <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
  </startup>

  <appSettings>
    <!-- Image_Quality, range 0 (greatest compression) - 100 (least compression) -->
    <add key="Image_Quality" value="50"/>
    <!-- Folder_Path where image files stored. Sub-folder will be crawled recursively -->
    <add key="Folder_Path" value="D:\Folder"/>
    <!-- Extensions that will be compressed, you can extend the list -->
    <add key="Allowed_Extensions" value=".jpg,.png,.ico"/>
  </appSettings>

  <log4net>
    <root>
      <level value="INFO"/>
      <appender-ref ref="RollingInfoFileAppender"/>
    </root>
    <appender name="RollingInfoFileAppender" type="log4net.Appender.RollingFileAppender">
      <file value="ImageCompressor.exe.Logs.txt"/>
      <appendToFile value="true" />
      <maximumFileSize value="1500KB" />
      <staticLogFileName value="false" />
      <preserveLogFileNameExtension value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <header value="====================[START]====================&#xD;&#xA;" />
        <footer value="====================[END]====================&#xD;&#xA;" />
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline"/>
      </layout>
      <threshold value="INFO" />
    </appender>
  </log4net>
</configuration>
```
