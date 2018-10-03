SDK for the Ungerboeck API 
==========================

You found the code tools for the Ungerboeck API!  This is a C# solution designed to introduce you and get you going quickly.

# Examples
This class library shows how to use every endpoint programmatically, including specific scenarios and comments giving tips.  After downloading the project, you can surf the code to find the method you need.  Also, please ensure your Visual Studio is set up to download Nuget Packages (Visual Studio->Options->Nuget Package Manager-> General -> Ensure these are checked: "Allow NuGet to download missing packages" and "Automatically check for missing packages during build in Visual Studio").  You can make a simple app to call the examples to see how they work.

## SDKWrapper 
Contains pre-made wrapper calls to quickly get your client connected to the Ungerboeck API.  This lives as a package on Nuget, but it coexists here to allow you to see the code.  
https://www.nuget.org/packages/Ungerboeck2094SDKWrapper/

## UngerboeckSDKPackage 
This contains pre-made models and constants to help your client code.  It only lives on Nuget.  
https://www.nuget.org/packages/Ungerboeck2094SDK/

At any time, you can see the matching Ungerboeck version of the SDKPackage or SDKWrapper by going to the assembly details.

##20.94 Updates:
-Custom Objects is now supported in the API.  Find more information in the published article on the Knowledgebase.  The Search function in the wrapper has a new parameter for specifying select properties to return.
-New Work Order Items endpoints
-New Department endpoints
-New Purchase Orders endpoints
