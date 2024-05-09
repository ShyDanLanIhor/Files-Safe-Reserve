using FilesSafeReserve.App.Entities.Params.ILogBuilder;
using FilesSafeReserve.App.Entities.Results.ILogBuilder;

namespace FilesSafeReserve.App.Builders.IBuilders;

/// <summary>
/// Interface for a logging service that provides methods for logging actions and functions.
/// </summary>
public interface ILogBuilder
{
    /// <summary>
    /// Logs a synchronous action.
    /// </summary>
    public IActionState WithAction(Action func);

    /// <summary>
    /// Logs an asynchronous action.
    /// </summary>
    public IActionAsyncState WithAction(Func<Task> func);

    /// <summary>
    /// Logs a synchronous function.
    /// </summary>
    public IFuncState<ResultType> WithFunc<ResultType>(Func<ResultType> func) where ResultType : class;

    /// <summary>
    /// Logs an asynchronous function.
    /// </summary>
    public IFuncAsyncState<ResultType> WithFunc<ResultType>(Func<Task<ResultType>> func) where ResultType : class;

    // Methods for logging multiple actions and functions

    /// <summary>
    /// Logs multiple synchronous actions.
    /// </summary>
    public IActionsState WithActions(IEnumerable<Action> func);

    /// <summary>
    /// Logs multiple asynchronous actions.
    /// </summary>
    public IActionsAsyncState WithActions(IEnumerable<Func<Task>> func);

    /// <summary>
    /// Logs multiple synchronous functions.
    /// </summary>
    public IFuncsState<ResultType> WithFuncs<ResultType>(IEnumerable<Func<ResultType>> func) where ResultType : class;

    /// <summary>
    /// Logs multiple asynchronous functions.
    /// </summary>
    public IFuncsAsyncState<ResultType> WithFuncs<ResultType>(IEnumerable<Func<Task<ResultType>>> func) where ResultType : class;


    /// <summary>
    /// Logs a synchronous action.
    /// </summary>
    public IActionState WithDelegate(Action func);

    /// <summary>
    /// Logs an asynchronous action.
    /// </summary>
    public IActionAsyncState WithDelegate(Func<Task> func);

    /// <summary>
    /// Logs a synchronous function.
    /// </summary>
    public IFuncState<ResultType> WithDelegate<ResultType>(Func<ResultType> func) where ResultType : class;

    /// <summary>
    /// Logs an asynchronous function.
    /// </summary>
    public IFuncAsyncState<ResultType> WithDelegate<ResultType>(Func<Task<ResultType>> func) where ResultType : class;

    // Methods for logging multiple actions and functions

    /// <summary>
    /// Logs multiple synchronous actions.
    /// </summary>
    public IActionsState WithDelegate(IEnumerable<Action> func);

    /// <summary>
    /// Logs multiple asynchronous actions.
    /// </summary>
    public IActionsAsyncState WithDelegate(IEnumerable<Func<Task>> func);

    /// <summary>
    /// Logs multiple synchronous functions.
    /// </summary>
    public IFuncsState<ResultType> WithDelegate<ResultType>(IEnumerable<Func<ResultType>> func) where ResultType : class;

    /// <summary>
    /// Logs multiple asynchronous functions.
    /// </summary>
    public IFuncsAsyncState<ResultType> WithDelegate<ResultType>(IEnumerable<Func<Task<ResultType>>> func) where ResultType : class;


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
        protected LogBuilderOpParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpParams parameters);

        /// <summary>
        /// Represents the executable state of a single action in the logging process.
        /// </summary>
        public interface IBuildableState : IActionState
        {
            /// <summary>
            /// Sets the criterion for executing the action.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IBuildableState WithCriterion(Func<bool> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the action.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Builds the action synchronously and returns the result entity.
            /// </summary>
            /// <returns>The result entity of the action execution.</returns>
            public LogBuilderResult Build();
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
        protected LogBuilderOpParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpParams parameters);

        /// <summary>
        /// Represents the executable state of an asynchronous action in the logging process.
        /// </summary>
        public interface IBuildableState : IActionAsyncState
        {
            /// <summary>
            /// Sets the criterion for executing the asynchronous action.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IBuildableState WithCriterion(Func<bool> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the asynchronous action.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Builds the asynchronous action and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the asynchronous action execution.</returns>
            public Task<LogBuilderResult> BuildAsync();
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
        protected LogBuilderOpParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpParams parameters);

        /// <summary>
        /// Represents the executable state of a function in the logging process.
        /// </summary>
        public interface IBuildableState : IFuncState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criterion for executing the function.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IBuildableState WithCriterion(Predicate<FuncReturnType> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the function.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Builds the function synchronously and returns the result entity.
            /// </summary>
            /// <returns>The result entity of the function execution.</returns>
            public LogBuilderResult<FuncReturnType> Build();
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
        protected LogBuilderOpParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpParams parameters);

        /// <summary>
        /// Represents the executable state of an asynchronous function in the logging process.
        /// </summary>
        public interface IBuildableState : IFuncAsyncState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criterion for executing the asynchronous function.
            /// </summary>
            /// <param name="criterion">The criterion function to be set.</param>
            /// <returns>The executable state instance with the criterion set.</returns>
            public new IBuildableState WithCriterion(Predicate<FuncReturnType> criterion)
            {
                Criterion = criterion;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the asynchronous function.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Builds the asynchronous function and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the asynchronous function execution.</returns>
            public Task<LogBuilderResult<FuncReturnType>> BuildAsync();
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
        protected LogBuilderOpsParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpsParams parameters);

        /// <summary>
        /// Represents the executable state of actions in the logging process.
        /// </summary>
        public interface IBuildableState : IActionsState
        {
            /// <summary>
            /// Sets the criteria for executing the actions.
            /// </summary>
            /// <param name="criteria">The criteria functions to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IBuildableState WithCriteria(IEnumerable<Func<bool>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the actions.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Builds the actions synchronously and returns the result entity.
            /// </summary>
            /// <returns>The result entity of the actions execution.</returns>
            public LogBuilderResult Build();
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
        protected LogBuilderOpsParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpsParams parameters);

        /// <summary>
        /// Represents the executable state of asynchronous actions in the logging process.
        /// </summary>
        public interface IBuildableState : IActionsAsyncState
        {
            /// <summary>
            /// Sets the criteria for executing the actions.
            /// </summary>
            /// <param name="criteria">The criteria functions to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IBuildableState WithCriteria(IEnumerable<Func<bool>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the actions.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Builds the asynchronous actions and returns a task representing the result entity.
            /// </summary>
            /// <returns>A task representing the result entity of the asynchronous actions execution.</returns>
            public Task<LogBuilderResult> BuildAsync();
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
        protected LogBuilderOpsParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpsParams parameters);

        /// <summary>
        /// Represents the executable state of function delegates in the logging process.
        /// </summary>
        public interface IBuildableState : IFuncsState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criteria for executing the function delegates.
            /// </summary>
            /// <param name="criteria">The criteria predicates to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IBuildableState WithCriteria(IEnumerable<Predicate<FuncReturnType>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the function delegates.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Builds the function delegates and returns a results entity.
            /// </summary>
            /// <returns>A results entity containing the results of the function delegates execution.</returns>
            public LogsBuilderResult<FuncReturnType> Build();
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
        protected LogBuilderOpsParams? Parameters { get; set; }

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
        public IBuildableState WithParameters(LogBuilderOpsParams parameters);

        /// <summary>
        /// Represents the executable state of asynchronous function delegates in the logging process.
        /// </summary>
        public interface IBuildableState : IFuncsAsyncState<FuncReturnType>
        {
            /// <summary>
            /// Sets the criteria for executing the asynchronous function delegates.
            /// </summary>
            /// <param name="criteria">The criteria predicates to be set.</param>
            /// <returns>The executable state instance with the criteria set.</returns>
            public new IBuildableState WithCriteria(IEnumerable<Predicate<FuncReturnType>> criteria)
            {
                Criteria = criteria;
                return this;
            }

            /// <summary>
            /// Sets the parameters for the asynchronous function delegates.
            /// </summary>
            /// <param name="parameters">The parameters to be set.</param>
            /// <returns>The executable state instance with the parameters set.</returns>
            public new IBuildableState WithParameters(LogBuilderOpsParams parameters)
            {
                Parameters = parameters;
                return this;
            }

            /// <summary>
            /// Asynchronously executes the function delegates and returns a results entity.
            /// </summary>
            /// <returns>A task representing the results entity of the asynchronous function delegates execution.</returns>
            public Task<LogsBuilderResult<FuncReturnType>> BuildAsync();
        }
    }
}
