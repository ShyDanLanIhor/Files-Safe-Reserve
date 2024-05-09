using FilesSafeReserve.App.Entities.Results.ILogBuilder;
using FilesSafeReserve.Infra.Repositories.IRepositories;

namespace FilesSafeReserve.Infra.Extensions;

public static class LogBuilderExtensions
{
    public static LogBuilderResult LogResult(this LogBuilderResult value, ILogRepo repo)
    {
        repo.Add(value.Log);

        return value;
    }

    public static LogBuilderResult<ResultType> LogResult<ResultType>(this LogBuilderResult<ResultType> value, ILogRepo repo)
    {
        repo.Add(value.Log);

        return value;
    }

    public static LogsBuilderResult<ResultType> LogResult<ResultType>(this LogsBuilderResult<ResultType> value, ILogRepo repo)
    {
        repo.Add(value.Log);

        return value;
    }

    public async static Task<LogBuilderResult> LogResultAsync(this LogBuilderResult value, ILogRepo repo)
    {
        await repo.AddAsync(value.Log);

        return value;
    }

    public async static Task<LogBuilderResult<ResultType>> LogResultAsync<ResultType>(this LogBuilderResult<ResultType> value, ILogRepo repo)
    {
        await repo.AddAsync(value.Log);

        return value;
    }

    public async static Task<LogsBuilderResult<ResultType>> LogResultAsync<ResultType>(this LogsBuilderResult<ResultType> value, ILogRepo repo)
    {
        await repo.AddAsync(value.Log);

        return value;
    }

    public async static Task<LogBuilderResult> LogResultAsync(this Task<LogBuilderResult> task, ILogRepo repo)
    {
        var value = await task;

        await repo.AddAsync(value.Log);

        return value;
    }

    public async static Task<LogBuilderResult<ResultType>> LogResultAsync<ResultType>(this Task<LogBuilderResult<ResultType>> task, ILogRepo repo)
    {
        var value = await task;

        await repo.AddAsync(value.Log);

        return value;
    }

    public async static Task<LogsBuilderResult<ResultType>> LogResultAsync<ResultType>(this Task<LogsBuilderResult<ResultType>> task, ILogRepo repo)
    {
        var value = await task;

        await repo.AddAsync((await task).Log);

        return value;
    }
}
