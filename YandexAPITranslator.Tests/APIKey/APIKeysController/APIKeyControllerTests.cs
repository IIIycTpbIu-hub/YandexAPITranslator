using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexAPITranslator.APIKey.APIKeysView;
using YandexAPITranslator.APIKey.APIKeysController;
using YandexAPITranslator.APIKey.APIKeysRepo;

namespace YandexAPITranslator.Tests.APIKey.APIKeysController
{
    [TestClass]
    public class APIKeyControllerTests
    {
        IKeysViewInputHandler _controller;
        APIKeysFileExistingChecker _checker;
        EmptyView _view;
        [TestInitialize]
        public void Initialize()
        {
            _checker = new APIKeysFileExistingChecker(Environment.CurrentDirectory);
            _view = new EmptyView();
            _controller = new ApiKeyController(_view);
        }

        [TestCleanup]
        public void Clean()
        {
            File.Delete(_checker.ConfigFilePath);
        }

        [TestMethod]
        public void CallVoidsWhenInitiallingTest()
        {
            Assert.IsTrue(_view.Set);
            Assert.IsTrue(_view.ShowAvaible);
        }

        [TestMethod]
        public void CallVoidsWhenAddingNewKey()
        {
            _controller.OnAddKey(this, "123");
            Assert.IsTrue(_view.ShowAvaible);
        }
        
        [TestMethod]
        public void CallVoidsWhenChosingNewKey()
        {
            _controller.OnAddKey(this, "1234");
            _controller.OnAddKey(this, "123");
            _view.ShowCurrent = false;
            _view.ShowAvaible = false;
            _controller.OnSelectKey(this, "123");
            Assert.IsTrue(_view.ShowCurrent);
            Assert.IsTrue(_view.ShowAvaible);
        }

        [TestMethod]
        public void CallVoidsWhenClosingView()
        {
            _controller.OnViewClosing(this, null);
            Assert.IsTrue(_view.Remove);
        }
    }
}
