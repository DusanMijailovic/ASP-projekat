using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
	public interface IUseCase
	{
		public int Id { get; }
		public string Name { get; }
	}

    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TResponse, TSearch> : IUseCase
    {
        TResponse Execute(TSearch search);
    }



}
