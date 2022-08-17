// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: big_oven.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Frontend {
  public static partial class CategoryService
  {
    static readonly string __ServiceName = "protos.CategoryService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Frontend.Void> __Marshaller_protos_Void = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Frontend.Void.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Frontend.Categories> __Marshaller_protos_Categories = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Frontend.Categories.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Frontend.CategoryId> __Marshaller_protos_CategoryId = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Frontend.CategoryId.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Frontend.Category> __Marshaller_protos_Category = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Frontend.Category.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Frontend.CategoryName> __Marshaller_protos_CategoryName = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Frontend.CategoryName.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Frontend.Void, global::Frontend.Categories> __Method_ListCategories = new grpc::Method<global::Frontend.Void, global::Frontend.Categories>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ListCategories",
        __Marshaller_protos_Void,
        __Marshaller_protos_Categories);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Frontend.CategoryId, global::Frontend.Category> __Method_GetCategory = new grpc::Method<global::Frontend.CategoryId, global::Frontend.Category>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCategory",
        __Marshaller_protos_CategoryId,
        __Marshaller_protos_Category);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Frontend.CategoryName, global::Frontend.Category> __Method_CreateCategory = new grpc::Method<global::Frontend.CategoryName, global::Frontend.Category>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateCategory",
        __Marshaller_protos_CategoryName,
        __Marshaller_protos_Category);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Frontend.Category, global::Frontend.Category> __Method_UpdateCategory = new grpc::Method<global::Frontend.Category, global::Frontend.Category>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateCategory",
        __Marshaller_protos_Category,
        __Marshaller_protos_Category);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Frontend.CategoryId, global::Frontend.Category> __Method_DeleteCategory = new grpc::Method<global::Frontend.CategoryId, global::Frontend.Category>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteCategory",
        __Marshaller_protos_CategoryId,
        __Marshaller_protos_Category);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Frontend.BigOvenReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CategoryService</summary>
    [grpc::BindServiceMethod(typeof(CategoryService), "BindService")]
    public abstract partial class CategoryServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Frontend.Categories> ListCategories(global::Frontend.Void request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Frontend.Category> GetCategory(global::Frontend.CategoryId request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Frontend.Category> CreateCategory(global::Frontend.CategoryName request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Frontend.Category> UpdateCategory(global::Frontend.Category request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Frontend.Category> DeleteCategory(global::Frontend.CategoryId request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CategoryService</summary>
    public partial class CategoryServiceClient : grpc::ClientBase<CategoryServiceClient>
    {
      /// <summary>Creates a new client for CategoryService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CategoryServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CategoryService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CategoryServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CategoryServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CategoryServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Categories ListCategories(global::Frontend.Void request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListCategories(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Categories ListCategories(global::Frontend.Void request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ListCategories, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Categories> ListCategoriesAsync(global::Frontend.Void request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListCategoriesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Categories> ListCategoriesAsync(global::Frontend.Void request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ListCategories, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category GetCategory(global::Frontend.CategoryId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetCategory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category GetCategory(global::Frontend.CategoryId request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> GetCategoryAsync(global::Frontend.CategoryId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetCategoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> GetCategoryAsync(global::Frontend.CategoryId request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category CreateCategory(global::Frontend.CategoryName request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateCategory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category CreateCategory(global::Frontend.CategoryName request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> CreateCategoryAsync(global::Frontend.CategoryName request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateCategoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> CreateCategoryAsync(global::Frontend.CategoryName request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category UpdateCategory(global::Frontend.Category request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateCategory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category UpdateCategory(global::Frontend.Category request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> UpdateCategoryAsync(global::Frontend.Category request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateCategoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> UpdateCategoryAsync(global::Frontend.Category request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category DeleteCategory(global::Frontend.CategoryId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCategory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Frontend.Category DeleteCategory(global::Frontend.CategoryId request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> DeleteCategoryAsync(global::Frontend.CategoryId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCategoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Frontend.Category> DeleteCategoryAsync(global::Frontend.CategoryId request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteCategory, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override CategoryServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CategoryServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(CategoryServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_ListCategories, serviceImpl.ListCategories)
          .AddMethod(__Method_GetCategory, serviceImpl.GetCategory)
          .AddMethod(__Method_CreateCategory, serviceImpl.CreateCategory)
          .AddMethod(__Method_UpdateCategory, serviceImpl.UpdateCategory)
          .AddMethod(__Method_DeleteCategory, serviceImpl.DeleteCategory).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CategoryServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_ListCategories, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Frontend.Void, global::Frontend.Categories>(serviceImpl.ListCategories));
      serviceBinder.AddMethod(__Method_GetCategory, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Frontend.CategoryId, global::Frontend.Category>(serviceImpl.GetCategory));
      serviceBinder.AddMethod(__Method_CreateCategory, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Frontend.CategoryName, global::Frontend.Category>(serviceImpl.CreateCategory));
      serviceBinder.AddMethod(__Method_UpdateCategory, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Frontend.Category, global::Frontend.Category>(serviceImpl.UpdateCategory));
      serviceBinder.AddMethod(__Method_DeleteCategory, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Frontend.CategoryId, global::Frontend.Category>(serviceImpl.DeleteCategory));
    }

  }
}
#endregion
