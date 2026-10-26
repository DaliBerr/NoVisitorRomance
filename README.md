# NoVisitorRomance

阻止非玩家角色向殖民者发起的浪漫关系成功，保留原有拦截方向。支持 RimWorld 1.5、1.6、1.7，需要先加载对应版本的 Harmony。

本次更新补充 1.7 构建，并修复无派系角色和空角色引用引起的异常。三个版本共享 1.6/Source 下的源码，各版本只加载自己的 NoVisitorRomance.dll。旧版本目录中误带的 RomanceAgeFix 和其他依赖不再作为本 Mod 发布。

## 构建与验证

需要 .NET 10 SDK 及 .NET Framework 4.7.2 参考程序集。1.5/1.6 使用各自 ExternalMods 目录中的对应原版参考及 Harmony 2；1.7 使用游戏根目录的原版参考及 Steam 工坊 2009463077 的 Harmony 3。

```powershell
./build.ps1
dotnet run --project Tests/Regression/Regression.csproj -c Release
./build.ps1 -Deploy
```

部署前将旧安装移到 Build/backups，失败时恢复，并保留 Steam 工坊 PublishedFileId。可用 RimWorldPath 参数指定游戏安装，或用 dotnet build 的 RimWorldManagedPath、HarmonyAssemblyPath 属性覆盖参考路径。

回归测试链接实际生产补丁，使用少量角色和 Harmony 特征替身验证访客、殖民者、无派系角色及空引用的组合。它不等于在真实游戏中验证 Harmony 补丁安装或玩家存档。

Git 保留源码、构建脚本、测试和三个 Mod DLL；依赖、构建缓存和安装备份被排除。

English: Supports RimWorld 1.5, 1.6 and 1.7. Prevents successful romance attempts initiated by non-player pawns toward colonists. Handles factionless pawns and missing references safely while retaining the existing direction of filtering.
