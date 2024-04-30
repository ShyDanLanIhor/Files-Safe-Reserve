using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Services.IServices;

/// <summary>
/// Interface for a logging service that provides methods for logging actions and functions.
/// </summary>
public interface ILoggerService
{
    /// <summary>
    /// Logs a synchronous action.
    /// </summary>
    public IActionState LogAction(Action func);

    /// <summary>
    /// Logs an asynchronous action.
    /// </summary>
    public IActionAsyncState LogAction(Func<Task> func);

    /// <summary>
    /// Logs a synchronous function.
    /// </summary>
    public IFuncState<ResultType> LogFunc<ResultType>(Func<ResultType> func) where ResultType : class;

    /// <summary>
    /// Logs an asynchronous function.
    /// </summary>
    public IFuncAsyncState<ResultType> LogFunc<ResultType>(Func<Task<ResultType>> func) where ResultType : class;

    // Methods for logging multiple actions and functions

    /// <summary>
    /// Logs multiple synchronous actions.
    /// </summary>
    public IActionsState LogActions(IEnumerable<Action> func);

    /// <summary>
    /// Logs multiple asynchronous actions.
    /// </summary>
    public IActionsAsyncState LogActions(IEnumerable<Func<Task>> func);

    /// <summary>
    /// Logs multiple synchronous functions.
    /// </summary>
    public IFuncsState<ResultType> LogFuncs<ResultType>(IEnumerable<Func<ResultType>> func) where ResultType : class;

    /// <summary>
    /// Logs multiple asynchronous functions.
    /// </summary>
    public IFuncsAsyncState<ResultType> LogFuncs<ResultType>(IEnumerable<Func<Task<ResultType>>> func) where ResultType : class;


    /// <summary>
    /// Logs a synchronous action.
    /// </summary>
    public IActionState Log(Action func);

    /// <summary>
    /// Logs an asynchronous action.
    /// </summary>
    public IActionAsyncState Log(Func<Task> func);

    /// <summary>
    /// Logs a synchronous function.
    /// </summary>
    public IFuncState<ResultType> Log<ResultType>(Func<ResultType> func) where ResultType : class;

    /// <summary>
    /// Logs an asynchronous function.
    /// </summary>
    public IFuncAsyncState<ResultType> Log<ResultType>(Func<Task<ResultType>> func) where ResultType : class;

    // Methods for logging multiple actions and functions

    /// <summary>
    /// Logs multiple synchronous actions.
    /// </summary>
    public IActionsState Log(IEnumerable<Action> func);

    /// <summary>
    /// Logs multiple asynchronous actions.
    /// </summary>
    public IActionsAsyncState Log(IEnumerable<Func<Task>> func);

    /// <summary>
    /// Logs multiple synchronous functions.
    /// </summary>
    public IFuncsState<ResultType> Log<ResultType>(IEnumerable<Func<ResultType>> func) where ResultType : class;

    /// <summary>
    /// Logs multiple asynchronous functions.
    /// </summary>
    public IFuncsAsyncState<ResultType> Log<ResultType>(IEnumerable<Func<Task<ResultType>>> func) where ResultType : class;


    /// <summary>
    /// Represents the state of a single action in the logging process.
    /// </summary>
    public interface IActionState
    {
        /// <summary>
        /// Gets or sets the action to be logged.
        /// </summary>
        protected Action Action { get; set; }

        /// <summary>
        /// Gets or sets the criterion for executing the action.
        /// </summary>
        protected Func<bool>? Criterion { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the action.
        /// </summary>
        protected LogOpParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criterion for executing the action.
        /// </summary>
        /// <param name="criterion">The criterion function to be set.</param>
        /// <returns>The action state instance with the criterion set.</returns>
        public IActionState WithCriterion(Func<bool> criterion)
        {
            Criterion = criterion;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the action.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpParams parameters);

        /// <summary>
        /// Represents the executable state of a single action in the logging process.
        /// </summary>
        public interface IExecutableState : IActionState
        {
            /// <summary>
            /// Sets the criterion for executing the action.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IExecutableState WithCriterion(Func<bool> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the action.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Executes the action synchronously and returns the result entity.
            /// </summary>
            /// <returns>The result entity of the action execution.</returns>
            public ResultEntity Execute();

            /// <summary>
            /// Executes the action asynchronously and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the action execution.</returns>
            public Task<ResultEntity> ExecuteAsync();
        }
    }


    /// <summary>
    /// Represents the state of an asynchronous action in the logging process.
    /// </summary>
    public interface IActionAsyncState
    {
        /// <summary>
        /// Gets or sets the asynchronous action to be logged.
        /// </summary>
        protected Func<Task> Action { get; set; }

        /// <summary>
        /// Gets or sets the criterion for executing the asynchronous action.
        /// </summary>
        protected Func<bool>? Criterion { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the asynchronous action.
        /// </summary>
        protected LogOpParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criterion for executing the asynchronous action.
        /// </summary>
        /// <param name="criterion">The criterion function to be set.</param>
        /// <returns>The action async state instance with the criterion set.</returns>
        public IActionAsyncState WithCriterion(Func<bool> criterion)
        {
            Criterion = criterion;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the asynchronous action.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpParams parameters);

        /// <summary>
        /// Represents the executable state of an asynchronous action in the logging process.
        /// </summary>
        public interface IExecutableState : IActionAsyncState
        {
            /// <summary>
            /// Sets the criterion for executing the asynchronous action.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IExecutableState WithCriterion(Func<bool> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the asynchronous action.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Executes the asynchronous action and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the asynchronous action execution.</returns>
            public Task<ResultEntity> ExecuteAsync();
        }
    }


    /// <summary>
    /// Represents the state of a function in the logging process.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the function.</typeparam>
    public interface IFuncState<FuncReturnType> where FuncReturnType : class
    {
        /// <summary>
        /// Gets or sets the function to be logged.
        /// </summary>
        protected Func<FuncReturnType> Func { get; set; }

        /// <summary>
        /// Gets or sets the criterion for executing the function.
        /// </summary>
        protected Predicate<FuncReturnType>? Criterion { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the function.
        /// </summary>
        protected LogOpParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criterion for executing the function.
        /// </summary>
        /// <param name="criterion">The criterion function to be set.</param>
        /// <returns>The function state instance with the criterion set.</returns>
        public IFuncState<FuncReturnType> WithCriterion(Predicate<FuncReturnType> criterion)
        {
            Criterion = criterion;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the function.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpParams parameters);

        /// <summary>
        /// Represents the executable state of a function in the logging process.
        /// </summary>
        public interface IExecutableState : IFuncState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criterion for executing the function.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IExecutableState WithCriterion(Predicate<FuncReturnType> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the function.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Executes the function synchronously and returns the result entity.
            /// </summary>
            /// <returns>The result entity of the function execution.</returns>
            public ResultEntity<FuncReturnType> Execute();

            /// <summary>
            /// Executes the function asynchronously and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the function execution.</returns>
            public Task<ResultEntity<FuncReturnType>> ExecuteAsync();
        }
    }


    /// <summary>
    /// Represents the state of an asynchronous function in the logging process.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the asynchronous function.</typeparam>
    public interface IFuncAsyncState<FuncReturnType> where FuncReturnType : class
    {
        /// <summary>
        /// Gets or sets the asynchronous function to be logged.
        /// </summary>
        protected Func<Task<FuncReturnType>> Func { get; set; }

        /// <summary>
        /// Gets or sets the criterion for executing the asynchronous function.
        /// </summary>
        protected Predicate<FuncReturnType>? Criterion { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the asynchronous function.
        /// </summary>
        protected LogOpParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criterion for executing the asynchronous function.
        /// </summary>
        /// <param name="criterion">The criterion function to be set.</param>
        /// <returns>The asynchronous function state instance with the criterion set.</returns>
        public IFuncAsyncState<FuncReturnType> WithCriterion(Predicate<FuncReturnType> criterion)
        {
            Criterion = criterion;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the asynchronous function.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpParams parameters);

        /// <summary>
        /// Represents the executable state of an asynchronous function in the logging process.
        /// </summary>
        public interface IExecutableState : IFuncAsyncState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criterion for executing the asynchronous function.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IExecutableState WithCriterion(Predicate<FuncReturnType> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the asynchronous function.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Executes the asynchronous function and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the asynchronous function execution.</returns>
            public Task<ResultEntity<FuncReturnType>> ExecuteAsync();
        }
    }


    /// <summary>
    /// Represents the state of actions in the logging process.
    /// </summary>
    public interface IActionsState
    {
        /// <summary>
        /// Gets or sets the actions to be logged.
        /// </summary>
        protected IEnumerable<Action> Actions { get; set; }

        /// <summary>
        /// Gets or sets the criteria for executing the actions.
        /// </summary>
        protected IEnumerable<Func<bool>>? Criteria { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the actions.
        /// </summary>
        protected LogOpsParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criteria for executing the actions.
        /// </summary>
        /// <param name="criteria">The criteria functions to be set.</param>
        /// <returns>The actions state instance with the criteria set.</returns>
        public IActionsState WithCriteria(IEnumerable<Func<bool>> criteria)
        {
            Criteria = criteria;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the actions.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpsParams parameters);

        /// <summary>
        /// Represents the executable state of actions in the logging process.
        /// </summary>
        public interface IExecutableState : IActionsState
        {
            /// <summary>
            /// Sets the criteria for executing the actions.
            /// </summary>
            /// <param name="criteria">The criteria functions to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IExecutableState WithCriteria(IEnumerable<Func<bool>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the actions.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Executes the actions synchronously and returns the result entity.
            /// </summary>
            /// <returns>The result entity of the actions execution.</returns>
            public ResultEntity Execute();

            /// <summary>
            /// Executes the actions asynchronously and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the actions execution.</returns>
            public Task<ResultEntity> ExecuteAsync();
        }
    }


    /// <summary>
    /// Represents the asynchronous state of actions in the logging process.
    /// </summary>
    public interface IActionsAsyncState
    {
        /// <summary>
        /// Gets or sets the asynchronous actions to be logged.
        /// </summary>
        protected IEnumerable<Func<Task>> Actions { get; set; }

        /// <summary>
        /// Gets or sets the criteria for executing the actions.
        /// </summary>
        protected IEnumerable<Func<bool>>? Criteria { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the actions.
        /// </summary>
        protected LogOpsParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criteria for executing the actions.
        /// </summary>
        /// <param name="criteria">The criteria functions to be set.</param>
        /// <returns>The actions async state instance with the criteria set.</returns>
        public IActionsAsyncState WithCriteria(IEnumerable<Func<bool>> criteria)
        {
            Criteria = criteria;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the actions.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpsParams parameters);

        /// <summary>
        /// Represents the executable state of asynchronous actions in the logging process.
        /// </summary>
        public interface IExecutableState : IActionsAsyncState
        {
            /// <summary>
            /// Sets the criteria for executing the actions.
            /// </summary>
            /// <param name="criteria">The criteria functions to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IExecutableState WithCriteria(IEnumerable<Func<bool>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the actions.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Executes the asynchronous actions and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the asynchronous actions execution.</returns>
            public Task<ResultEntity> ExecuteAsync();
        }
    }


    /// <summary>
    /// Represents the state of function delegates in the logging process.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the function delegates.</typeparam>
    public interface IFuncsState<FuncReturnType> where FuncReturnType : class
    {
        /// <summary>
        /// Gets or sets the function delegates to be logged.
        /// </summary>
        protected IEnumerable<Func<FuncReturnType>> Funcs { get; set; }

        /// <summary>
        /// Gets or sets the criteria for executing the function delegates.
        /// </summary>
        protected IEnumerable<Predicate<FuncReturnType>>? Criteria { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the function delegates.
        /// </summary>
        protected LogOpsParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criteria for executing the function delegates.
        /// </summary>
        /// <param name="criteria">The criteria predicates to be set.</param>
        /// <returns>The function states instance with the criteria set.</returns>
        public IFuncsState<FuncReturnType> WithCriteria(IEnumerable<Predicate<FuncReturnType>> criteria)
        {
            Criteria = criteria;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the function delegates.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpsParams parameters);

        /// <summary>
        /// Represents the executable state of function delegates in the logging process.
        /// </summary>
        public interface IExecutableState : IFuncsState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criteria for executing the function delegates.
            /// </summary>
            /// <param name="criteria">The criteria predicates to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IExecutableState WithCriteria(IEnumerable<Predicate<FuncReturnType>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the function delegates.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Executes the function delegates and returns a results entity.
            /// </summary>
            /// <returns>A results entity containing the results of the function delegates execution.</returns>
            public ResultsEntity<FuncReturnType> Execute();

            /// <summary>
            /// Asynchronously executes the function delegates and returns a task representing the results entity.
            /// </summary>
            /// <returns>A task representing the results entity of the asynchronous function delegates execution.</returns>
            public Task<ResultsEntity<FuncReturnType>> ExecuteAsync();
        }
    }

    /// <summary>
    /// Represents the asynchronous state of function delegates in the logging process.
    /// </summary>
    /// <typeparam name="FuncReturnType">The return type of the asynchronous function delegates.</typeparam>
    public interface IFuncsAsyncState<FuncReturnType> where FuncReturnType : class
    {
        /// <summary>
        /// Gets or sets the asynchronous function delegates to be logged.
        /// </summary>
        protected IEnumerable<Func<Task<FuncReturnType>>> Funcs { get; set; }

        /// <summary>
        /// Gets or sets the criteria for executing the asynchronous function delegates.
        /// </summary>
        protected IEnumerable<Predicate<FuncReturnType>>? Criteria { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the asynchronous function delegates.
        /// </summary>
        protected LogOpsParams? Parameters { get; set; }

        /// <summary>
        /// Sets the criteria for executing the asynchronous function delegates.
        /// </summary>
        /// <param name="criteria">The criteria predicates to be set.</param>
        /// <returns>The asynchronous function states instance with the criteria set.</returns>
        public IFuncsAsyncState<FuncReturnType> WithCriteria(IEnumerable<Predicate<FuncReturnType>> criteria)
        {
            Criteria = criteria;
            return this;
        }

        /// <summary>
        /// Sets the parameters for the asynchronous function delegates.
        /// </summary>
        /// <param name="parameters">The parameters to be set.</param>
        /// <returns>The executable state instance with the parameters set.</returns>
        public IExecutableState WithParameters(LogOpsParams parameters);

        /// <summary>
        /// Represents the executable state of asynchronous function delegates in the logging process.
        /// </summary>
        public interface IExecutableState : IFuncsAsyncState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criteria for executing the asynchronous function delegates.
            /// </summary>
            /// <param name="criteria">The criteria predicates to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IExecutableState WithCriteria(IEnumerable<Predicate<FuncReturnType>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the asynchronous function delegates.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IExecutableState WithParameters(LogOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Asynchronously executes the function delegates and returns a results entity.
            /// </summary>
            /// <returns>A task representing the results entity of the asynchronous function delegates execution.</returns>
            public Task<ResultsEntity<FuncReturnType>> ExecuteAsync();
        }
    }

    /// <summary>
    /// Represents the parameters for a single log operation.
    /// </summary>
    public class LogOpParams
    {
        /// <summary>
        /// Gets or sets the ID of the virtual safe details associated with the log operation.
        /// </summary>
        public required Guid VirtualSafeDetailsId { get; set; }

        /// <summary>
        /// Gets or sets the path of the item associated with the log operation.
        /// </summary>
        public required string ItemPath { get; set; }

        /// <summary>
        /// Gets or sets the type of the log operation.
        /// </summary>
        public required LogOperationModel.Types Type { get; set; }
    }

    /// <summary>
    /// The `LogOpsParams` class is used to log operations parameters.
    /// </summary>
    public class LogOpsParams
    {
        /// <summary>
        /// Gets or sets the ID of the virtual safe details. This is a required property.
        /// </summary>
        /// <value>The ID of the virtual safe details.</value>
        /// <see cref="System.Guid"/>
        public required Guid VirtualSafeDetailsId { get; set; }

        /// <summary>
        /// Gets or sets the collection of operations parameters. This is a required property.
        /// </summary>
        /// <value>The collection of operations parameters.</value>
        /// <see cref="System.Collections.Generic.ICollection{T}"/>
        public required ICollection<OperationsParams> Operations { get; set; }

        /// <summary>
        /// The `OperationsParams` class is used to define the parameters for each operation.
        /// </summary>
        public class OperationsParams
        {
            /// <summary>
            /// Gets or sets the path of the item. This is a required property.
            /// </summary>
            /// <value>The path of the item.</value>
            public required string ItemPath { get; set; }

            /// <summary>
            /// Gets or sets the type of the log operation. This is a required property.
            /// </summary>
            /// <value>The type of the log operation.</value>
            /// <see cref="LogOperationModel.Types"/>
            public required LogOperationModel.Types Type { get; set; }
        }
    }


    /// <summary>
    /// Represents the result of a logging operation.
    /// </summary>
    public record ResultEntity(LogModel Log)
    {
        /// <summary>
        /// Gets a value indicating whether all operations in the log were successful.
        /// </summary>
        public bool IsSucceeded { get => Log.Operations.All(el => el.IsSucceeded is true); }
    }

    /// <summary>
    /// Represents the result of a logging operation with a specific result type.
    /// </summary>
    public record ResultEntity<ResultType>(LogModel Log, ResultType? ActionResult)
    {
        /// <summary>
        /// Gets a value indicating whether all operations in the log were successful.
        /// </summary>
        public bool IsSucceeded { get => Log.Operations.All(el => el.IsSucceeded is true); }
    }

    /// <summary>
    /// Represents the result of logging multiple operations with a specific result type.
    /// </summary>
    public record ResultsEntity<ResultType>(LogModel Log, IEnumerable<ResultType?>? ActionResult)
    {
        /// <summary>
        /// Gets a value indicating whether all operations in the log were successful.
        /// </summary>
        public bool IsSucceeded { get => Log.Operations.All(el => el.IsSucceeded is true); }
    }
}
