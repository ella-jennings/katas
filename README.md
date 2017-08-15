## C# Katas ##

As a foundation developer I'm trying to get to grips with unit testing and using this as a personal space to do so.

# Setup #

In visual studio, set up a new `Project` then `Unit Test Project` (I set mine up in c#).

Once the project is up, access `Project` -> `Manage NuGet packages` and search for NUNIT under the `Browse` tab. Install the latest version.

Ensure your project is in the format:

```
Using NUnit.Framework;

namespace kataName
{
	[TestClass]
	public class KataTests
	{
		[Test]
		public void YourTestNameShouldBeHere()
		{
			Your Test Here
		}
	}
} 
```

# Unit Test #

Written in the form:

**Arrange**
**Act**
**Assert**

# Running the tests #



# Good Practice # 

+ Always start with a failing test before you make it pass
+ Write one test at a time
+ Never commit a failing test