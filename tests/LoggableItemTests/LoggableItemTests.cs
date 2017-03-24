using AutoLogger;
using System;
using Xunit;

namespace LoggableItemTests {
    public class LoggableItemTests {

        [Fact]
        public void SingleItemFlagWorks() {
            LoggableItem item = LoggableItem.PublicMethods;
            Assert.True(item == LoggableItem.PublicMethods);
        }

        [Fact]
        public void AllFlagsSetWorks() {
            LoggableItem items = LoggableItem.PublicMethods |
                LoggableItem.InternalMethods |
                LoggableItem.PrivateMethods;

            Assert.True(
                (items & LoggableItem.PublicMethods) != 0 &&
                (items & LoggableItem.InternalMethods) != 0 &&
                (items & LoggableItem.PrivateMethods) != 0
            );
        }

        [Fact]
        public void MultipleButNotAllFlagsSetWorks() {
            LoggableItem items = LoggableItem.PublicMethods | LoggableItem.PrivateMethods;

            Assert.True(
                (items & LoggableItem.PublicMethods) != 0 &&
                (items & LoggableItem.PrivateMethods) != 0 &&
                (items & LoggableItem.InternalMethods) == 0
            );
        }

        //TODO(Logan) -> Write unit test that gets the classes and loggable information;
        [Fact]
        public void LoggableAttributeHasItems() {

        }

    }

    [Loggable(LoggableItems = LoggableItem.PublicMethods | LoggableItem.PrivateMethods)]
    public class LoggableClassWithAttribute {}
}
