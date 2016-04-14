# SimplePersistence.UoW.NH
SimplePersistence.UoW.NH offers implementations to the SimplePersistence.UoW using NHibernate 4 as the ORM.

## Installation
This library can be installed via NuGet package. Just run the following command:

```powershell
Install-Package SimplePersistence.UoW.NH -Pre
```

## Usage

```csharp
public class ApplicationRepository : NHQueryableRepository<Application, string>, IApplicationRepository
{
	public ApplicationRepository(ISession session) 
		: base(session)
	{
	}

	#region Overrides of NHQueryableRepository<Application,string>

	public override IQueryable<Application> QueryById(string id)
	{
		return Query().Where(e => e.Id == id);
	}

	#endregion
}

public class LevelRepository : NHQueryableRepository<Level, string>, ILevelRepository
{
	public LevelRepository(ISession session) 
		: base(session)
	{
	}

	#region Overrides of NHQueryableRepository<Level,string>

	public override IQueryable<Level> QueryById(string id)
	{
		return Query().Where(e => e.Id == id);
	}

	#endregion
}

public class LogRepository : NHQueryableRepository<Log, long>, ILogRepository
{
	public LogRepository(ISession session) 
		: base(session)
	{
	}

	#region Overrides of NHQueryableRepository<Log,long>

	public override IQueryable<Log> QueryById(long id)
	{
		return Query().Where(e => e.Id == id);
	}

	#endregion
	
	public async Task<IEnumerable<Log>> GetAllCreatedAfterAsync(DateTimeOffset on, CancellationToken ct)
	{
		return await Task.Run(() => Query().Where(e => e.CreatedOn >= on).ToArray());
	}
}

public class LoggingWorkArea : NHWorkArea, ILoggingWorkArea
{
	public LoggingWorkArea(ISession session)
		: base(session)
	{
		Applications = new ApplicationRepository(session);
		Levels => new LevelRepository(session);
		Logs => new LogRepository(session);
	}

	public IApplicationRepository Applications { get; }

	public ILevelRepository Levels { get; }

	public ILogRepository Logs { get; }
} 

public class AppUnitOfWork : NHUnitOfWork, IAppUnitOfWork
{
	public AppUnitOfWork(ISession session) 
		: base(session)
	{
		Logging = new LoggingWorkArea(session);
	}
	
	public ILoggingWorkArea Logging { get; }
}
```
