//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Cms
{
    /// <summary>
    /// Site Service class
    /// </summary>
    public partial class SiteService : Service<Site, SiteDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteService"/> class
        /// </summary>
        public SiteService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteService"/> class
        /// </summary>
        public SiteService(IRepository<Site> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override Site CreateNew()
        {
            return new Site();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<SiteDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<SiteDto> QueryableDto( IQueryable<Site> items )
        {
            return items.Select( m => new SiteDto()
                {
                    IsSystem = m.IsSystem,
                    Name = m.Name,
                    Description = m.Description,
                    Theme = m.Theme,
                    DefaultPageId = m.DefaultPageId,
                    FaviconUrl = m.FaviconUrl,
                    AppleTouchIconUrl = m.AppleTouchIconUrl,
                    FacebookAppId = m.FacebookAppId,
                    FacebookAppSecret = m.FacebookAppSecret,
                    LoginPageReference = m.LoginPageReference,
                    RegistrationPageReference = m.RegistrationPageReference,
                    ErrorPage = m.ErrorPage,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( Site item, out string errorMessage )
        {
            errorMessage = string.Empty;
            RockContext context = new RockContext();
            context.Database.Connection.Open();

            using ( var cmdCheckRef = context.Database.Connection.CreateCommand() )
            {
                cmdCheckRef.CommandText = string.Format( "select count(*) from Page where SiteId = {0} ", item.Id );
                var result = cmdCheckRef.ExecuteScalar();
                int? refCount = result as int?;
                if ( refCount > 0 )
                {
                    Type entityType = RockContext.GetEntityFromTableName( "Page" );
                    string friendlyName = entityType != null ? entityType.GetFriendlyTypeName() : "Page";

                    errorMessage = string.Format("This {0} is assigned to a {1}.", Site.FriendlyTypeName, friendlyName);
                    return false;
                }
            }

            return true;
        }
    }
}
