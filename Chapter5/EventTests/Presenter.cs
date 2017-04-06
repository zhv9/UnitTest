using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace EventTests
{
    public class Presenter
    {
        private readonly IView _view;

        public Presenter(IView view)
        {
            _view = view;
            //在触发事件后调用OnLoaded方法
            this._view.Loaded += OnLoaded;

        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }
    }


    //有两个依赖，一个日志和一个视图
    class Presenter2
    {
        private readonly IView _view;
        private readonly ILogger _log;

        public Presenter2(IView view, ILogger log)
        {
            _view = view;
            _log = log;
            //发生Loaded事件时，调用OnLoaded
            this._view.Loaded += OnLoaded;
            //发生ErrorOccured事件时，调用OnError()方法，接收一个text
            this._view.ErrorOccured += OnError;

        }

        private void OnError(string text)
        {
            _log.LogError(text);
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }
    }

    public interface IView
    {
        event Action Loaded;
        event Action<string> ErrorOccured;
        void Render(string text);
    }

}
