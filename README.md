# TireTreads

This repository contains a VB .NET worker service used to export tire inventory data from SQL Server and send the result to an SFTP server.  The original VB project can be found under `OLD/` for reference.

## Service overview

The service exports inventory for **all companies** and **all tire parts**.  Brands may be excluded through configuration.  The generated CSV file is uploaded to an SFTP server with a configurable remote file name.

### Configuration

Edit `Service/appsettings.json` and provide the SQL connection string, export directory, SFTP details, and any brands that should be excluded.  `RemoteFileName` sets the name used when uploading to SFTP and for the local export file.

### Running

```
dotnet run --project Service/TireTreadsService.vbproj
```

When deployed as a Windows service, the worker repeats on the interval defined by `Worker:IntervalMinutes`.
