using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace EventTests
{
    [TestFixture]
    public class EventRelatedTests
    {
        //模拟事件并触发
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            Presenter p = new Presenter(mockView);
            //使用NSubstitute触发事件
            mockView.Loaded += Raise.Event<Action>();

            //验证测试中是否调用了view的Render方法
            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        //模拟一个日志对象和一个视图
        [Test]
        public void ctor_WhenViewHasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            Presenter2 p = new Presenter2(stubView, mockLogger);

            //1. 桩触发错误事件，由于OnError方法需要一个string所以事件要带一个参数
            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

            //2. 使用模拟对象检查日志调用
            mockLogger.Received().LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }

        ////测试事件是否触发
        ////比较简单的方法是：在测试方法内部使用一个匿名委托，手工注册这个方法。下面是伪代码。
        //[Test]
        //public void EventFiringManual()
        //{
        //    bool loadFired = false;
        //    SomeView view = new SomeView();
        //    //这个委托只记录这个事件是否触发
        //    view.Load += Delegate
        //    {
        //        loadFired = true;
        //    };
        //    view.DoSomethingThatEventuallyFiresThisEvent();
        //    Assert.IsTrue(loadFired);
        //}
    }
}
