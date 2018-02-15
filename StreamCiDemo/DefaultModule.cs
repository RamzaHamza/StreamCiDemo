using Autofac;
using Autofac.Core;


namespace StreamCiDemo
{
	internal class DefaultModule : Module
	{

		protected override void Load(ContainerBuilder builder)
		{

			builder.RegisterType<MyRepository>().As<IRepository>();

			base.Load(builder);
		}

	}


	public interface IRepository
	{

		object GetById(int id);

	}

	public class MyRepository : IRepository
	{
		public object GetById(int id)
		{
			return new object();
		}
	}

}