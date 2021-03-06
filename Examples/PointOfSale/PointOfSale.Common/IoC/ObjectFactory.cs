﻿using System;
using System.Threading;
using StructureMap;
using StructureMap.Graph;

namespace PointOfSale.Common.IoC
{
    public static class ObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
                    new Lazy<Container>(CreateDefaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container CreateDefaultContainer()
        {
            return new Container(x => x.Scan(s =>
                                             {
                                                 s.AssembliesFromApplicationBaseDirectory();
                                                 s.LookForRegistries();
                                             }));
        }
    }
}
