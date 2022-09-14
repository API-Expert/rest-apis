using System;
namespace Domain
{
	public class ExecutionResult<T>
	{

		public IReadOnlyList<string>? Errors { get;  }
		public T? Result { get;  }


		public ExecutionResult(T result)
		{
			Result = result;
			
		}

		public ExecutionResult(string[] errors)
		{
			Errors = errors;
		}

		public bool HasErrors()
		{

			return Errors != null;
		}


	}
}

