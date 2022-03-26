using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollipop.Core.Models
{
    /// <summary>
    /// Base abstract class for purpose of extracting ID
    /// </summary>
    public abstract class Base
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        [NotNull]
        public int Id { get; private set; }
    }
}
