﻿using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDb.Fluent
{
    /// <summary>
    /// Provides a mechanism for creating an entity.
    /// </summary>
    /// <typeparam name="TSelfWrapper">The wrapping type (e.g., <see cref="IDatabase"/>).</typeparam>
    /// <typeparam name="TUnderlying">The underlying type (e.g., <see cref="Microsoft.Azure.Documents.Database"/>).</typeparam>
    public interface ICreateable<TSelfWrapper, in TUnderlying>
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="obj">The underlying entity to create.</param>
        /// <returns>The wrapped entity.</returns>
        TSelfWrapper Create(TUnderlying obj);

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="obj">The underlying entity to create.</param>
        /// <returns>The wrapped entity.</returns>
        Task<TSelfWrapper> CreateAsync(TUnderlying obj);

        /// <summary>
        /// Creates a new entities.
        /// </summary>
        /// <param name="objs">The underlying entities to create.</param>
        /// <returns>The wrapped entities.</returns>
        IEnumerable<TSelfWrapper> Create(IEnumerable<TUnderlying> objs);

        /// <summary>
        /// Creates a new entities.
        /// </summary>
        /// <param name="objs">The underlying entities to create.</param>
        /// <returns>The wrapped entities.</returns>
        Task<IEnumerable<TSelfWrapper>> CreateAsync(IEnumerable<TUnderlying> objs);

        /// <summary>
        /// Set request options before create.
        /// </summary>
        /// <param name="options">The <see cref="RequestOptions"/>.</param>
        /// <returns>The wrapped entity.</returns>
        TSelfWrapper WithRequestOptions(RequestOptions options);
    }

    /// <summary>
    /// Provides a mechanism for reading from an entity.
    /// </summary>
    /// <typeparam name="TUnderlying">The underlying type (e.g., <see cref="Microsoft.Azure.Documents.Database"/>).</typeparam>
    public interface IReadable<TUnderlying>
    {
        /// <summary>
        /// Reads the underlying entity of this wrapper.
        /// </summary>
        /// <returns>The underlying entity.</returns>
        TUnderlying Read();

        /// <summary>
        /// Reads the underlying entity of this wrapper.
        /// </summary>
        /// <returns>The underlying entity.</returns>
        Task<TUnderlying> ReadAsync();
    }

    /// <summary>
    /// Provides a mechanism for updating an entity.
    /// </summary>
    /// <typeparam name="TSelfWrapper">The wrapping type (e.g., <see cref="IDatabase"/>).</typeparam>
    /// <typeparam name="TUnderlying">The underlying type (e.g., <see cref="Microsoft.Azure.Documents.Database"/>).</typeparam>
    public interface IUpdateable<TSelfWrapper, in TUnderlying>
    {
        /// <summary>
        /// Updates this existing entity.
        /// </summary>
        /// <param name="obj">The new entity.</param>
        /// <returns>The wrapped entity.</returns>
        TSelfWrapper Update(TUnderlying obj);

        /// <summary>
        /// Updates this existing entity.
        /// </summary>
        /// <param name="obj">The new entity.</param>
        /// <returns>The wrapped entity.</returns>
        Task<TSelfWrapper> UpdateAsync(TUnderlying obj);
    }

    /// <summary>
    /// Provides a mechanism for editing an entity.
    /// </summary>
    /// <typeparam name="TSelfWrapper">The wrapping type (e.g., <see cref="IDatabase"/>).</typeparam>
    /// <typeparam name="TUnderlying">The underlying type (e.g., <see cref="Microsoft.Azure.Documents.Database"/>).</typeparam>
    public interface IEditable<TSelfWrapper, TUnderlying>
    {
        /// <summary>
        /// Edits this document in place and commits the change.
        /// </summary>
        /// <param name="mutator">A mutator action.</param>
        /// <returns>The wrapped document.</returns>
        TSelfWrapper Edit(Action<TUnderlying> mutator);

        /// <summary>
        /// Edits this document in place and commits the change.
        /// </summary>
        /// <param name="mutator">A mutator action.</param>
        /// <returns>The wrapped document.</returns>
        Task<TSelfWrapper> EditAsync(Action<TUnderlying> mutator);
    }

    /// <summary>
    /// Provides a mechanism for deleting an entity.
    /// </summary>
    public interface IDeleteable
    {
        /// <summary>
        /// Deletes this entity.
        /// </summary>
        void Delete();

        /// <summary>
        /// Deletes this entity.
        /// </summary>
        Task DeleteAsync();
    }

    /// <summary>
    /// Provides a mechanism for adding an entity to a collection type.
    /// </summary>
    /// <typeparam name="TSelfWrapper">The wrapped item type (e.g., <see cref="IDatabase"/>).</typeparam>
    /// <typeparam name="TItemUnderlying">The underlying item type (e.g., <see cref="Microsoft.Azure.Documents.Database"/>).</typeparam>
    public interface IAddable<TSelfWrapper, in TItemUnderlying>
    {
        /// <summary>
        /// Adds an entity to this collection type.
        /// </summary>
        /// <param name="obj">The underlying entity.</param>
        /// <returns>This collection.</returns>
        TSelfWrapper Add(TItemUnderlying obj);

        /// <summary>
        /// Adds an entity to this collection type.
        /// </summary>
        /// <param name="obj">The underlying entity.</param>
        /// <returns>This collection.</returns>
        Task<TSelfWrapper> AddAsync(TItemUnderlying obj);

        /// <summary>
        /// Adds entities to this collection type.
        /// </summary>
        /// <param name="objs">The underlying entities.</param>
        /// <returns>This collection.</returns>
        TSelfWrapper Add(IEnumerable<TItemUnderlying> objs);

        /// <summary>
        /// Adds entities to this collection type.
        /// </summary>
        /// <param name="objs">The underlying entities.</param>
        /// <returns>This collection.</returns>
        Task<TSelfWrapper> AddAsync(IEnumerable<TItemUnderlying> objs);
    }

    /// <summary>
    /// Provides a mechanism for clearing an entity collection.
    /// </summary>
    public interface IClearable<TSelfWrapper>
    {
        /// <summary>
        /// Clears this entity collection.
        /// </summary>
        TSelfWrapper Clear();

        /// <summary>
        /// Clears this entity collection.
        /// </summary>
        Task<TSelfWrapper> ClearAsync();
    }

    /// <summary>
    /// Provides a mechanism for querying an entity for its children.
    /// </summary>
    /// <typeparam name="TItemUnderlying">The underlying item type (e.g., <see cref="Microsoft.Azure.Documents.Database"/>).</typeparam>
    public interface IQueryableEntity<out TItemUnderlying>
    {
        /// <summary>
        /// Gets the queryable collection of items (e.g., <see cref="IDocument{TUnderlying}"/>).
        /// </summary>
        IOrderedQueryable<TItemUnderlying> Query { get; }
    }

    /// <summary>
    /// Provides a mechanism for querying an entity for its wrapped children.
    /// </summary>
    /// <typeparam name="TWrapper">The item type (e.g., <see cref="Database"/>).</typeparam>
    public interface IQueryableWrappedEntity<out TWrapper>
    {
        /// <summary>
        /// Gets the queryable collection of wrapped items (e.g., <see cref="IDocument{TUnderlying}"/>).
        /// </summary>
        IEnumerable<TWrapper> WrappedQuery { get; }
    }

    /// <summary>
    /// Provides a representation of entities in DocumentDB.
    /// </summary>
    /// <typeparam name="TSelfWrapper">The type of the wrapper (e.g., <see cref="IDatabase"/>).</typeparam>
    public interface IEntity<TSelfWrapper>
    {
        /// <summary>
        /// The underlying <see cref="DocumentClient"/>.
        /// </summary>
        DocumentClient Client { get; }

        /// <summary>
        /// The underlying Id of this entity.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// The full SelfLink for this entity.
        /// </summary>
        Uri GetLink();

        /// <summary>
        /// The full SelfLink for this entity.
        /// </summary>
        Task<Uri> GetLinkAsync();

        /// <summary>
        /// Initializes the entity.
        /// </summary>
        /// <returns>The wrapped entity.</returns>
        Task<TSelfWrapper> EnsureAsync();
    }

    public interface ICrd<TWrapperSelf, TUnderlying> :
        IEntity<TWrapperSelf>,
        ICreateable<TWrapperSelf, TUnderlying>,
        IReadable<TUnderlying>,
        IDeleteable
    {

    }

    public interface ICrud<TWrapperSelf, TUnderlying> :
        ICrd<TWrapperSelf, TUnderlying>,
        IUpdateable<TWrapperSelf, TUnderlying>,
        IEditable<TWrapperSelf, TUnderlying>
    {

    }

    public interface ICollectionCrud<TWrapperSelf, TItemUnderlying, TItemWrapper> :
        IAddable<TWrapperSelf, TItemUnderlying>,
        IClearable<TWrapperSelf>,
        IQueryableEntity<TItemUnderlying>,
        IQueryableWrappedEntity<TItemWrapper>
    {

    }

    /// <summary>
    /// Provides a representation of a top-level DocumentDB account.
    /// </summary>
    public interface IAccount : 
        IReadable<Microsoft.Azure.Documents.DatabaseAccount>, 
        ICollectionCrud<IAccount, Microsoft.Azure.Documents.Database, IDatabase>
    {
        /// <summary>
        /// The underlying <see cref="DocumentClient"/>.
        /// </summary>
        DocumentClient Client { get; }

        /// <summary>
        /// Gets (or creates, if needed) a <see cref="Microsoft.Azure.Documents.Database"/>.
        /// </summary>
        /// <param name="dbId">The Id of the <see cref="Microsoft.Azure.Documents.Database"/>.</param>
        /// <returns>The wrapped <see cref="Microsoft.Azure.Documents.Database"/>.</returns>
        IDatabase Database(string dbId = null);
    }

    /// <summary>
    /// Provides a representation of a <see cref="Microsoft.Azure.Documents.Database"/>.
    /// </summary>
    public interface IDatabase :
        ICrd<IDatabase, Microsoft.Azure.Documents.Database>, 
        ICollectionCrud<IDatabase, Microsoft.Azure.Documents.DocumentCollection, IDocumentCollection<HasId>>
    {
        /// <summary>
        /// This database's parent <see cref="IAccount"/>.
        /// </summary>
        IAccount Account { get; }

        /// <summary>
        /// Gets (or creates, if needed) a <see cref="Microsoft.Azure.Documents.DocumentCollection"/>.
        /// If a <paramref name="collectionId" /> is not provided, then the Id of the collection will be inferred by <typeparamref name="TItemUnderlying" />.
        /// </summary>
        /// <param name="collectionId">The Id of the <see cref="Microsoft.Azure.Documents.DocumentCollection"/>.</param>
        /// <returns>The wrapped <see cref="Microsoft.Azure.Documents.DocumentCollection"/>.</returns>
        IDocumentCollection<TItemUnderlying> Collection<TItemUnderlying>(string collectionId = null) where TItemUnderlying : class, IId, new();
    }

    /// <summary>
    /// Provides a representation of a <see cref="Microsoft.Azure.Documents.DocumentCollection"/>.
    /// </summary>
    /// <typeparam name="TItemUnderlying">The underlying item type (e.g., <code>TodoItem</code>).</typeparam>
    public interface IDocumentCollection<TItemUnderlying> :
        ICrud<IDocumentCollection<TItemUnderlying>, Microsoft.Azure.Documents.DocumentCollection>,
        ICollectionCrud<IDocumentCollection<TItemUnderlying>, TItemUnderlying, IDocument<TItemUnderlying>>
        where TItemUnderlying : class, IId, new()
    {
        /// <summary>
        /// This collection's parent <see cref="IDatabase"/>.
        /// </summary>
        IDatabase Database { get; }

        /// <summary>
        /// Gets a <see cref="Microsoft.Azure.Documents.Document"/>.
        /// If the <paramref name="documentId"/> is empty, then a ghost document wrapper is created.
        /// </summary>
        /// <param name="documentId">The Id of the <see cref="Microsoft.Azure.Documents.Document"/>.</param>
        /// <returns>The wrapped <see cref="Microsoft.Azure.Documents.Document"/>.</returns>
        IDocument<TItemUnderlying> Document(string documentId = null);

        /// <summary>
        /// Gets the changes in the  collection of <see cref="IDocument{TUnderlying}"/>s since the last call.
        /// </summary>
        IEnumerable<TItemUnderlying> GetChanges();

        /// <summary>
        /// Gets the changes in the  collection of <see cref="IDocument{TUnderlying}"/>s since the last call.
        /// </summary>
        Task<IEnumerable<TItemUnderlying>> GetChangesAsync();

        /// <summary>
        /// Cast this <see cref="IDocumentCollection{TUnderlying}"/> to <see cref="IDocumentCollection{T}"/>
        /// </summary>
        /// <typeparam name="T">The new type.</typeparam>
        /// <returns>The new <see cref="IDocumentCollection{T}"/></returns>
        IDocumentCollection<T> Cast<T>() where T : class, TItemUnderlying, new();
    }

    /// <summary>
    /// Provides a representation of a <see cref="Microsoft.Azure.Documents.Document"/>.
    /// </summary>
    /// <typeparam name="TUnderlying">The underlying type (e.g., <code>TodoItem</code>).</typeparam>
    public interface IDocument<TUnderlying> :
        ICrud<IDocument<TUnderlying>, TUnderlying>
        where TUnderlying : class, IId, new()
    {
        /// <summary>
        /// This document's parent <see cref="IDocumentCollection{TItemUnderlying}"/>.
        /// </summary>
        IDocumentCollection<TUnderlying> Collection { get; }

        /// <summary>
        /// Cast this <see cref="IDocument{TUnderlying}"/> to <see cref="IDocument{T}"/>
        /// </summary>
        /// <typeparam name="T">The new type.</typeparam>
        /// <returns>The new <see cref="IDocument{T}"/></returns>
        IDocument<T> Cast<T>() where T : class, TUnderlying, new();
    }

    /// <summary>
    /// Provides a representation of an object with a serializeable Id.
    /// </summary>
    public interface IId
    {
        /// <summary>
        /// The required "Id" for DocumentDb documents.
        /// </summary>
        [JsonProperty("id")]
        string Id { get; set; }
    }

    /// <summary>
    /// Provides a base class for document types.
    /// </summary>
    public class HasId : IId
    {
        public string Id { get; set; }
    }
}
