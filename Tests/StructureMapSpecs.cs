using System;
using System.Linq;

using Machine.Specifications;
using StructureMap;
using StructureMap.Graph;

using StructureMapIntro.Plugins;
using StructureMapIntro.Services;

namespace Tests
{
  // ReSharper disable InconsistentNaming
  // ReSharper disable UnusedMember.Local
  public class StructureMapSpecs
  {
    private static Container container;
    private static MyService instance;

    private Establish context = () => 
      container = new Container(x => x.Scan(
        s =>
          {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory();
            s.WithDefaultConventions();
            s.LookForRegistries();
            s.SingleImplementationsOfInterface();
            s.AddAllTypesOf<IMyPlugin>();
          }));

    private Because _of = () => instance = (MyService)container.GetInstance<IMyService>();

    private It _instance_should_not_be_null = () => instance.ShouldNotBeNull();

    private It _instance_property_should_not_be_null = () => instance.MyRepository.ShouldBeNull();

    private It _plugins_should_not_be_empty = () =>
                                               {
                                                 instance.Plugins.ShouldNotBeNull();
                                                 instance.Plugins.Any().ShouldBeTrue();
                                               };

    private It _what_do_i_have = () =>
                                   {
                                     var whatDoIHave = container.WhatDoIHave();
                                     Console.WriteLine(whatDoIHave);
                                   };

    private It _should_describe_build_plan = () =>
                                               {
                                                 var buildPlan = container.Model.For<IMyService>().Default.DescribeBuildPlan();
                                                 Console.WriteLine(buildPlan);
                                               };
  }
  // ReSharper restore InconsistentNaming
  // ReSharper restore UnusedMember.Local
}
