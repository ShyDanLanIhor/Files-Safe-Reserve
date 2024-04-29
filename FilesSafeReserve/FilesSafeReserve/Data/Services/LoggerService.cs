using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Data.Services.IServices;
using static FilesSafeReserve.Data.Services.IServices.ILoggerService;

namespace FilesSafeReserve.Data.Services;

/// <summary>
/// The `LoggerService` class provides methods for logging actions and functions.
/// It implements the `ILoggerService` interface.
/// </summary>
/// <remarks>
/// Initializes a new instance of the `LoggerService` class.
/// </remarks>
/// <param name="LogRepo">The repository for logs.</param>
public class LoggerService(ILogRepo LogRepo) : ILoggerService
{
    /// <summary>
    /// Logs an action and returns an `IActionState`.
    /// </summary>
    /// <param name="func">The action to log.</param>
    /// <returns>An `IActionState` representing the logged action.</returns>
    public IActionState LogAction(Action func) => new ActionState(func, LogRepo);

    /// <summary>
    /// Logs an asynchronous action and returns an `IActionAsyncState`.
    /// </summary>
    /// <param name="func">The asynchronous action to log.</param>
    /// <returns>An `IActionAsyncState` representing the logged asynchronous action.</returns>
    public IActionAsyncState LogAction(Func<Task> func) => new ActionAsyncState(func, LogRepo);

    /// <summary>
    /// Logs multiple actions and returns an `IActionsState`.
    /// </summary>
    /// <param name="func">The actions to log.</param>
    /// <returns>An `IActionsState` representing the logged actions.</returns>
    public IActionsState LogActions(IEnumerable<Action> func) => new ActionsState(func, LogRepo);

    /// <summary>
    /// Logs multiple asynchronous actions and returns an `IActionsAsyncState`.
    /// </summary>
    /// <param name="func">The asynchronous actions to log.</param>
    /// <returns>An `IActionsAsyncState` representing the logged asynchronous actions.</returns>
    public IActionsAsyncState LogActions(IEnumerable<Func<Task>> func) => new ActionsAsyncState(func, LogRepo);

    /// <summary>
    /// Logs a function and returns an `IFuncState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the function.</typeparam>
    /// <param name="func">The function to log.</param>
    /// <returns>An `IFuncState` representing the logged function.</returns>
    public IFuncState<ResultType> LogFunc<ResultType>(Func<ResultType> func) where ResultType : class
        => new FuncState<ResultType>(func, LogRepo);

    /// <summary>
    /// Logs an asynchronous function and returns an `IFuncAsyncState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the function.</typeparam>
    /// <param name="func">The asynchronous function to log.</param>
    /// <returns>An `IFuncAsyncState` representing the logged asynchronous function.</returns>
    public IFuncAsyncState<ResultType> LogFunc<ResultType>(Func<Task<ResultType>> func) where ResultType : class
        => new FuncAsyncState<ResultType>(func, LogRepo);

    /// <summary>
    /// Logs multiple functions and returns an `IFuncsState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the functions.</typeparam>
    /// <param name="func">The functions to log.</param>
    /// <returns>An `IFuncsState` representing the logged functions.</returns>
    public IFuncsState<ResultType> LogFuncs<ResultType>(IEnumerable<Func<ResultType>> func) where ResultType : class
        => new FuncsState<ResultType>(func, LogRepo);

    /// <summary>
    /// Logs multiple asynchronous functions and returns an `IFuncsAsyncState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the functions.</typeparam>
    /// <param name="func">The asynchronous functions to log.</param>
    /// <returns>An `IFuncsAsyncState` representing the logged asynchronous functions.</returns>
    public IFuncsAsyncState<ResultType> LogFuncs<ResultType>(IEnumerable<Func<Task<ResultType>>> func) where ResultType : class
        => new FuncsAsyncState<ResultType>(func, LogRepo);

    /// <summary>
    /// Logs an action and returns an `IActionState`.
    /// </summary>
    /// <param name="func">The action to log.</param>
    /// <returns>An `IActionState` representing the logged action.</returns>
    public IActionState Log(Action func) => new ActionState(func, LogRepo);

    /// <summary>
    /// Logs an asynchronous action and returns an `IActionAsyncState`.
    /// </summary>
    /// <param name="func">The asynchronous action to log.</param>
    /// <returns>An `IActionAsyncState` representing the logged asynchronous action.</returns>
    public IActionAsyncState Log(Func<Task> func) => new ActionAsyncState(func, LogRepo);

    /// <summary>
    /// Logs multiple actions and returns an `IActionsState`.
    /// </summary>
    /// <param name="func">The actions to log.</param>
    /// <returns>An `IActionsState` representing the logged actions.</returns>
    public IActionsState Log(IEnumerable<Action> func) => new ActionsState(func, LogRepo);

    /// <summary>
    /// Logs multiple asynchronous actions and returns an `IActionsAsyncState`.
    /// </summary>
    /// <param name="func">The asynchronous actions to log.</param>
    /// <returns>An `IActionsAsyncState` representing the logged asynchronous actions.</returns>
    public IActionsAsyncState Log(IEnumerable<Func<Task>> func) => new ActionsAsyncState(func, LogRepo);

    /// <summary>
    /// Logs a function and returns an `IFuncState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the function.</typeparam>
    /// <param name="func">The function to log.</param>
    /// <returns>An `IFuncState` representing the logged function.</returns>
    public IFuncState<ResultType> Log<ResultType>(Func<ResultType> func) where ResultType : class
        => new FuncState<ResultType>(func, LogRepo);

    /// <summary>
    /// Logs an asynchronous function and returns an `IFuncAsyncState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the function.</typeparam>
    /// <param name="func">The asynchronous function to log.</param>
    /// <returns>An `IFuncAsyncState` representing the logged asynchronous function.</returns>
    public IFuncAsyncState<ResultType> Log<ResultType>(Func<Task<ResultType>> func) where ResultType : class
        => new FuncAsyncState<ResultType>(func, LogRepo);

    /// <summary>
    /// Logs multiple functions and returns an `IFuncsState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the functions.</typeparam>
    /// <param name="func">The functions to log.</param>
    /// <returns>An `IFuncsState` representing the logged functions.</returns>
    public IFuncsState<ResultType> Log<ResultType>(IEnumerable<Func<ResultType>> func) where ResultType : class
        => new FuncsState<ResultType>(func, LogRepo);

    /// <summary>
    /// Logs multiple asynchronous functions and returns an `IFuncsAsyncState`.
    /// </summary>
    /// <typeparam name="ResultType">The type of the return value of the functions.</typeparam>
    /// <param name="func">The asynchronous functions to log.</param>
    /// <returns>An `IFuncsAsyncState` representing the logged asynchronous functions.</returns>
    public IFuncsAsyncState<ResultType> Log<ResultType>(IEnumerable<Func<Task<ResultType>>> func) where ResultType : class
        => new FuncsAsyncState<ResultType>(func, LogRepo);

    /// <summary>
    /// Initializes a new `LogModel` with the start timestamp and the ID of the virtual safe details.
    /// </summary>
    /// <param name="Id">The ID of the virtual safe details.</param>
    /// <returns>A new `LogModel`.</returns>
    private static LogModel InitStartLog(Guid Id)
        => new()
        {
            StartTimestamp = DateTime.Now,
            VirtualSafeDetailsId = Id,
            Operations = []
        };

    /// <summary>
    /// Creates a new `LogOperationModel` for an action.
    /// </summary>
    /// <param name="predicate">The predicate to determine if the action is successful.</param>
    /// <param name="type">The type of the log operation.</param>
    /// <param name="path">The path of the item.</param>
    /// <returns>A new `LogOperationModel`.</returns>
    private static LogOperationModel CreateActionLogOp(Func<bool>? predicate, LogOperationModel.Types type, string path)
        => new()
        {
            IsSucceeded = predicate is null || predicate(),
            PerformTimestamp = DateTime.Now,
            Type = type,
            ItemPath = path,
        };


    /// <summary>
    /// Creates a new `LogOperationModel` for a function.
    /// </summary>
    /// <typeparam name="ReturnType">The type of the return value of the function.</typeparam>
    /// <param name="result">The result of the function.</param>
    /// <param name="predicate">The predicate to determine if the function is successful.</param>
    /// <param name="type">The type of the log operation.</param>
    /// <param name="path">The path of the item.</param>
    private static LogOperationModel CreateFuncLogOp<ReturnType>(ReturnType result, Predicate<ReturnType>? predicate, LogOperationModel.Types type, string path)
        => new()
        {
            IsSucceeded = predicate is null || predicate(result),
            PerformTimestamp = DateTime.Now,
            Type = type,
            ItemPath = path,
        };

    /// <summary>
    /// Creates a new `LogOperationModel` for a function.
    /// </summary>
    /// <param name="type">The type of the log operation.</param>
    /// <param name="path">The path of the item.</param>
    private static LogOperationModel CreateFailedLogOp(LogOperationModel.Types type, string path)
        => new()
        {
            IsSucceeded = false,
            PerformTimestamp = DateTime.Now,
            Type = type,
            ItemPath = path,
        };

    /// <summary>
    /// Represents the state of an action to be logged.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ActionState"/> class with the specified action and log repository.
    /// </remarks>
    /// <param name="func">The action to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class ActionState(Action func, ILogRepo logRepo) : IActionState
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <summary>
        /// Gets or sets the action to be executed.
        /// </summary>
        public Action Action { get; set; } = func;

        /// <summary>
        /// Gets or sets the criterion for executing the action.
        /// </summary>
        public Func<bool>? Criterion { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the action.
        /// </summary>
        public LogOpParams? Parameters { get; set; }

        /// <inheritdoc/>
        IActionState.IExecutableState IActionState.WithParameters(LogOpParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Action, Criterion, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of an action to be logged.
        /// </summary>
        public class ExecutableState : ActionState, IActionState.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified action, criterion, parameters, and log repository.
            /// </summary>
            /// <param name="func">The action to be executed.</param>
            /// <param name="criterion">The criterion for executing the action.</param>
            /// <param name="parameters">The parameters for the action.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(Action func, Func<bool>? criterion, LogOpParams parameters, ILogRepo logRepo) : base(func, logRepo)
            {
                Criterion = criterion;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            ResultEntity IActionState.IExecutableState.Execute()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                try
                {
                    Action();

                    log.Operations.Add(CreateActionLogOp(Criterion, Parameters.Type, Parameters.ItemPath));
                }
                catch (Exception)
                {
                    log.Operations.Add(CreateFailedLogOp(Parameters.Type, Parameters.ItemPath));
                }

                log.EndTimestamp = DateTime.Now;

                LogRepo.Add(log);

                return new(log);
            }

            /// <inheritdoc/>
            async Task<ResultEntity> IActionState.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                try
                {
                    Action();

                    log.Operations.Add(CreateActionLogOp(Criterion, Parameters.Type, Parameters.ItemPath));
                }
                catch (Exception)
                {
                    log.Operations.Add(CreateFailedLogOp(Parameters.Type, Parameters.ItemPath));
                }

                log.EndTimestamp = DateTime.Now;

                await LogRepo.AddAsync(log);

                return new(log);
            }
        }
    }


    /// <summary>
    /// Represents the state of an asynchronous action to be logged.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ActionAsyncState"/> class with the specified asynchronous action and log repository.
    /// </remarks>
    /// <param name="func">The asynchronous action to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class ActionAsyncState(Func<Task> func, ILogRepo logRepo) : IActionAsyncState
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <summary>
        /// Gets or sets the asynchronous action to be executed.
        /// </summary>
        public Func<Task> Action { get; set; } = func;

        /// <summary>
        /// Gets or sets the criterion for executing the action.
        /// </summary>
        public Func<bool>? Criterion { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the action.
        /// </summary>
        public LogOpParams? Parameters { get; set; }

        /// <inheritdoc/>
        IActionAsyncState.IExecutableState IActionAsyncState.WithParameters(LogOpParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Action, Criterion, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of an asynchronous action to be logged.
        /// </summary>
        public class ExecutableState : ActionAsyncState, IActionAsyncState.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified asynchronous action, criterion, parameters, and log repository.
            /// </summary>
            /// <param name="func">The asynchronous action to be executed.</param>
            /// <param name="criterion">The criterion for executing the action.</param>
            /// <param name="parameters">The parameters for the action.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(Func<Task> func, Func<bool>? criterion, LogOpParams parameters, ILogRepo logRepo) : base(func, logRepo)
            {
                Criterion = criterion;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            async Task<ResultEntity> IActionAsyncState.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                try
                {
                    await Action();

                    log.Operations.Add(CreateActionLogOp(Criterion, Parameters.Type, Parameters.ItemPath));
                }
                catch (Exception)
                {
                    log.Operations.Add(CreateFailedLogOp(Parameters.Type, Parameters.ItemPath));
                }

                log.EndTimestamp = DateTime.Now;

                await LogRepo.AddAsync(log);

                return new(log);
            }
        }
    }


    /// <summary>
    /// Represents the state of logging multiple actions.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ActionsState"/> class with the specified actions and log repository.
    /// </remarks>
    /// <param name="funcs">The actions to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class ActionsState(IEnumerable<Action> funcs, ILogRepo logRepo) : IActionsState
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <summary>
        /// Gets or sets the actions to be executed.
        /// </summary>
        public IEnumerable<Action> Actions { get; set; } = funcs;

        /// <summary>
        /// Gets or sets the criteria for executing each action.
        /// </summary>
        public IEnumerable<Func<bool>>? Criteria { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the actions.
        /// </summary>
        public LogOpsParams? Parameters { get; set; }

        /// <inheritdoc/>
        IActionsState.IExecutableState IActionsState.WithParameters(LogOpsParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Actions, Criteria, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of logging multiple actions.
        /// </summary>
        public class ExecutableState : ActionsState, IActionsState.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified actions, criteria, parameters, and log repository.
            /// </summary>
            /// <param name="funcs">The actions to be executed.</param>
            /// <param name="criteria">The criteria for executing each action.</param>
            /// <param name="parameters">The parameters for the actions.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(IEnumerable<Action> funcs, IEnumerable<Func<bool>>? criteria, LogOpsParams parameters, ILogRepo logRepo) : base(funcs, logRepo)
            {
                Criteria = criteria;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            ResultEntity IActionsState.IExecutableState.Execute()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                var actionsList = Actions.ToList();
                var criteriaList = Criteria!.ToList();
                var operationsParametersList = Parameters.Operations.ToList();

                for (int i = 0; i < actionsList.Count; i++)
                {
                    try
                    {
                        actionsList[i]();

                        log.Operations.Add(CreateActionLogOp(criteriaList[i], operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    catch (Exception)
                    {
                        log.Operations.Add(CreateFailedLogOp(operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                }

                log.EndTimestamp = DateTime.Now;

                LogRepo.Add(log);

                return new(log);
            }

            /// <inheritdoc/>
            async Task<ResultEntity> IActionsState.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                var actionsList = Actions.ToList();
                var criteriaList = Criteria!.ToList();
                var operationsParametersList = Parameters.Operations.ToList();

                for (int i = 0; i < actionsList.Count; i++)
                {
                    try
                    {
                        actionsList[i]();

                        log.Operations.Add(CreateActionLogOp(criteriaList[i], operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    catch (Exception)
                    {
                        log.Operations.Add(CreateFailedLogOp(operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                }

                log.EndTimestamp = DateTime.Now;

                await LogRepo.AddAsync(log);

                return new(log);
            }
        }
    }


    /// <summary>
    /// Represents the state of logging multiple asynchronous actions.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ActionsAsyncState"/> class with the specified asynchronous actions and log repository.
    /// </remarks>
    /// <param name="funcs">The asynchronous actions to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class ActionsAsyncState(IEnumerable<Func<Task>> funcs, ILogRepo logRepo) : IActionsAsyncState
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <summary>
        /// Gets or sets the asynchronous actions to be executed.
        /// </summary>
        public IEnumerable<Func<Task>> Actions { get; set; } = funcs;

        /// <summary>
        /// Gets or sets the criteria for executing each action.
        /// </summary>
        public IEnumerable<Func<bool>>? Criteria { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the actions.
        /// </summary>
        public LogOpsParams? Parameters { get; set; }

        /// <inheritdoc/>
        IActionsAsyncState.IExecutableState IActionsAsyncState.WithParameters(LogOpsParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Actions, Criteria, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of logging multiple asynchronous actions.
        /// </summary>
        public class ExecutableState : ActionsAsyncState, IActionsAsyncState.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified asynchronous actions, criteria, parameters, and log repository.
            /// </summary>
            /// <param name="funcs">The asynchronous actions to be executed.</param>
            /// <param name="criteria">The criteria for executing each action.</param>
            /// <param name="parameters">The parameters for the actions.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(IEnumerable<Func<Task>> funcs, IEnumerable<Func<bool>>? criteria, LogOpsParams parameters, ILogRepo logRepo) : base(funcs, logRepo)
            {
                Criteria = criteria;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            async Task<ResultEntity> IActionsAsyncState.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                var actionsList = Actions.ToList();
                var criteriaList = Criteria!.ToList();
                var operationsParametersList = Parameters.Operations.ToList();

                for (int i = 0; i < actionsList.Count; i++)
                {
                    try
                    {
                        await actionsList[i]();

                        log.Operations.Add(CreateActionLogOp(criteriaList[i], operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    catch (Exception)
                    {
                        log.Operations.Add(CreateFailedLogOp(operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                }

                log.EndTimestamp = DateTime.Now;

                await LogRepo.AddAsync(log);

                return new(log);
            }
        }
    }


    /// <summary>
    /// Represents the state of logging a single synchronous function.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the function.</typeparam>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FuncState{FuncReturnType}"/> class with the specified synchronous function and log repository.
    /// </remarks>
    /// <param name="func">The synchronous function to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class FuncState<FuncReturnType>(Func<FuncReturnType> func, ILogRepo logRepo) : IFuncState<FuncReturnType> where FuncReturnType : class
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <inheritdoc/>
        public Func<FuncReturnType> Func { get; set; } = func;

        /// <inheritdoc/>
        public Predicate<FuncReturnType>? Criterion { get; set; }

        /// <inheritdoc/>
        public LogOpParams? Parameters { get; set; }

        /// <inheritdoc/>
        IFuncState<FuncReturnType>.IExecutableState IFuncState<FuncReturnType>.WithParameters(LogOpParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Func, Criterion, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of logging a single synchronous function.
        /// </summary>
        public class ExecutableState : FuncState<FuncReturnType>, IFuncState<FuncReturnType>.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified synchronous function, criterion, parameters, and log repository.
            /// </summary>
            /// <param name="func">The synchronous function to be executed.</param>
            /// <param name="criterion">The criterion for executing the function.</param>
            /// <param name="parameters">The parameters for the function.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(Func<FuncReturnType> func, Predicate<FuncReturnType>? criterion, LogOpParams parameters, ILogRepo logRepo) : base(func, logRepo)
            {
                Criterion = criterion;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            ResultEntity<FuncReturnType> IFuncState<FuncReturnType>.IExecutableState.Execute()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);
                FuncReturnType? result = default;

                try
                {
                    result = Func();
                    log.Operations.Add(CreateFuncLogOp(result, Criterion, Parameters.Type, Parameters.ItemPath));
                }
                catch (Exception)
                {
                    log.Operations.Add(CreateFailedLogOp(Parameters.Type, Parameters.ItemPath));
                }

                log.EndTimestamp = DateTime.Now;
                LogRepo.Add(log);

                return new(log, result);
            }

            /// <inheritdoc/>
            async Task<ResultEntity<FuncReturnType>> IFuncState<FuncReturnType>.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);
                FuncReturnType? result = default;

                try
                {
                    result = Func();
                    log.Operations.Add(CreateFuncLogOp(result, Criterion, Parameters.Type, Parameters.ItemPath));
                }
                catch (Exception)
                {
                    log.Operations.Add(CreateFailedLogOp(Parameters.Type, Parameters.ItemPath));
                }

                log.EndTimestamp = DateTime.Now;
                await LogRepo.AddAsync(log);

                return new(log, result);
            }
        }
    }


    /// <summary>
    /// Represents the state of logging a single asynchronous function.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the asynchronous function.</typeparam>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FuncAsyncState{FuncReturnType}"/> class with the specified asynchronous function and log repository.
    /// </remarks>
    /// <param name="func">The asynchronous function to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class FuncAsyncState<FuncReturnType>(Func<Task<FuncReturnType>> func, ILogRepo logRepo) : IFuncAsyncState<FuncReturnType> where FuncReturnType : class
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <inheritdoc/>
        public Func<Task<FuncReturnType>> Func { get; set; } = func;

        /// <inheritdoc/>
        public Predicate<FuncReturnType>? Criterion { get; set; }

        /// <inheritdoc/>
        public LogOpParams? Parameters { get; set; }

        /// <inheritdoc/>
        IFuncAsyncState<FuncReturnType>.IExecutableState IFuncAsyncState<FuncReturnType>.WithParameters(LogOpParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Func, Criterion, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of logging a single asynchronous function.
        /// </summary>
        public class ExecutableState : FuncAsyncState<FuncReturnType>, IFuncAsyncState<FuncReturnType>.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified asynchronous function, criterion, parameters, and log repository.
            /// </summary>
            /// <param name="func">The asynchronous function to be executed.</param>
            /// <param name="criterion">The criterion for executing the function.</param>
            /// <param name="parameters">The parameters for the function.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(Func<Task<FuncReturnType>> func, Predicate<FuncReturnType>? criterion, LogOpParams parameters, ILogRepo logRepo) : base(func, logRepo)
            {
                Criterion = criterion;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            async Task<ResultEntity<FuncReturnType>> IFuncAsyncState<FuncReturnType>.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);
                FuncReturnType? result = default;

                try
                {
                    result = await Func();

                    log.Operations.Add(CreateFuncLogOp(result, Criterion, Parameters.Type, Parameters.ItemPath));
                }
                catch (Exception)
                {
                    log.Operations.Add(CreateFailedLogOp(Parameters.Type, Parameters.ItemPath));
                }

                log.EndTimestamp = DateTime.Now;
                await LogRepo.AddAsync(log);

                return new(log, result);
            }
        }
    }


    /// <summary>
    /// Represents the state of logging multiple synchronous functions.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the synchronous functions.</typeparam>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FuncsState{FuncReturnType}"/> class with the specified synchronous functions and log repository.
    /// </remarks>
    /// <param name="funcs">The collection of synchronous functions to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class FuncsState<FuncReturnType>(IEnumerable<Func<FuncReturnType>> funcs, ILogRepo logRepo) : IFuncsState<FuncReturnType> where FuncReturnType : class
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <inheritdoc/>
        public IEnumerable<Func<FuncReturnType>> Funcs { get; set; } = funcs;

        /// <inheritdoc/>
        public IEnumerable<Predicate<FuncReturnType>>? Criteria { get; set; }

        /// <inheritdoc/>
        public LogOpsParams? Parameters { get; set; }

        /// <inheritdoc/>
        IFuncsState<FuncReturnType>.IExecutableState IFuncsState<FuncReturnType>.WithParameters(LogOpsParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Funcs, Criteria, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of logging multiple synchronous functions.
        /// </summary>
        public class ExecutableState : FuncsState<FuncReturnType>, IFuncsState<FuncReturnType>.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified synchronous functions, criteria, parameters, and log repository.
            /// </summary>
            /// <param name="funcs">The collection of synchronous functions to be executed.</param>
            /// <param name="criteria">The collection of criteria for executing the functions.</param>
            /// <param name="parameters">The parameters for the functions.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(IEnumerable<Func<FuncReturnType>> funcs, IEnumerable<Predicate<FuncReturnType>>? criteria, LogOpsParams parameters, ILogRepo logRepo) : base(funcs, logRepo)
            {
                Criteria = criteria;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            ResultsEntity<FuncReturnType> IFuncsState<FuncReturnType>.IExecutableState.Execute()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                var funcsList = Funcs.ToList();
                var criteriaList = Criteria!.ToList();
                var operationsParametersList = Parameters.Operations.ToList();
                var resultsList = new List<FuncReturnType?>();

                for (int i = 0; i < funcsList.Count; i++)
                {
                    FuncReturnType? result = default;

                    try
                    {
                        result = funcsList[i]();

                        log.Operations.Add(CreateFuncLogOp(result, criteriaList[i], operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    catch (Exception)
                    {
                        log.Operations.Add(CreateFailedLogOp(operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    resultsList.Add(result);
                }

                log.EndTimestamp = DateTime.Now;

                LogRepo.Add(log);

                return new(log, resultsList);
            }

            /// <inheritdoc/>
            async Task<ResultsEntity<FuncReturnType>> IFuncsState<FuncReturnType>.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                var funcsList = Funcs.ToList();
                var criteriaList = Criteria!.ToList();
                var operationsParametersList = Parameters.Operations.ToList();
                var resultsList = new List<FuncReturnType?>();

                for (int i = 0; i < funcsList.Count; i++)
                {
                    FuncReturnType? result = default;

                    try
                    {
                        result = funcsList[i]();

                        log.Operations.Add(CreateFuncLogOp(result, criteriaList[i], operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    catch (Exception)
                    {
                        log.Operations.Add(CreateFailedLogOp(operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    resultsList.Add(result);
                }

                log.EndTimestamp = DateTime.Now;

                await LogRepo.AddAsync(log);

                return new(log, resultsList);
            }
        }
    }

    /// <summary>
    /// Represents the state of logging multiple asynchronous functions.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the asynchronous functions.</typeparam>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FuncsAsyncState{FuncReturnType}"/> class with the specified asynchronous functions and log repository.
    /// </remarks>
    /// <param name="funcs">The asynchronous functions to be executed.</param>
    /// <param name="logRepo">The repository for logging.</param>
    public class FuncsAsyncState<FuncReturnType>(IEnumerable<Func<Task<FuncReturnType>>> funcs, ILogRepo logRepo) : IFuncsAsyncState<FuncReturnType> where FuncReturnType : class
    {
        protected ILogRepo LogRepo { get; } = logRepo;

        /// <inheritdoc/>
        public IEnumerable<Func<Task<FuncReturnType>>> Funcs { get; set; } = funcs;

        /// <inheritdoc/>
        public IEnumerable<Predicate<FuncReturnType>>? Criteria { get; set; }

        /// <inheritdoc/>
        public LogOpsParams? Parameters { get; set; }

        /// <inheritdoc/>
        IFuncsAsyncState<FuncReturnType>.IExecutableState IFuncsAsyncState<FuncReturnType>.WithParameters(LogOpsParams parameters)
        {
            Parameters = parameters;
            return new ExecutableState(Funcs, Criteria, parameters, LogRepo);
        }

        /// <summary>
        /// Represents the executable state of logging multiple asynchronous functions.
        /// </summary>
        public class ExecutableState : FuncsAsyncState<FuncReturnType>, IFuncsAsyncState<FuncReturnType>.IExecutableState
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExecutableState"/> class with the specified asynchronous functions, criteria, parameters, and log repository.
            /// </summary>
            /// <param name="funcs">The asynchronous functions to be executed.</param>
            /// <param name="criteria">The criteria for executing the functions.</param>
            /// <param name="parameters">The parameters for the functions.</param>
            /// <param name="logRepo">The repository for logging.</param>
            public ExecutableState(IEnumerable<Func<Task<FuncReturnType>>> funcs, IEnumerable<Predicate<FuncReturnType>>? criteria, LogOpsParams parameters, ILogRepo logRepo) : base(funcs, logRepo)
            {
                Criteria = criteria;
                Parameters = parameters;
            }

            /// <inheritdoc/>
            async Task<ResultsEntity<FuncReturnType>> IFuncsAsyncState<FuncReturnType>.IExecutableState.ExecuteAsync()
            {
                LogModel log = InitStartLog(Parameters!.VirtualSafeDetailsId);

                var funcsList = Funcs.ToList();
                var criteriaList = Criteria!.ToList();
                var operationsParametersList = Parameters.Operations.ToList();
                var resultsList = new List<FuncReturnType?>();

                for (int i = 0; i < funcsList.Count; i++)
                {
                    FuncReturnType? result = default;

                    try
                    {
                        result = await funcsList[i]();

                        log.Operations.Add(CreateFuncLogOp(result, criteriaList[i], operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    catch (Exception)
                    {
                        log.Operations.Add(CreateFailedLogOp(operationsParametersList[i].Type, operationsParametersList[i].ItemPath));
                    }
                    resultsList.Add(result);
                }

                log.EndTimestamp = DateTime.Now;

                await LogRepo.AddAsync(log);

                return new(log, resultsList);
            }
        }
    }
}
