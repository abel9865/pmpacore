using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Helpers
{
    public static class UtilHelpers
    {
        public static string Flatten(this IEnumerable elems, string separator)
{
    if (elems == null)
    {
        return null;
    }

    StringBuilder sb = new StringBuilder();
    foreach (object elem in elems)
    {
        if (sb.Length > 0)
        {
            sb.Append(separator);
        }

        sb.Append(elem);
    }

    return sb.ToString();
}
    
    
    
        public static string FlattenErrors( IEnumerable<IdentityError> elems, string separator)
{
    if (elems == null)
    {
        return null;
    }

    StringBuilder sb = new StringBuilder();
    foreach (IdentityError elem in elems)
    {
        if (sb.Length > 0)
        {
            sb.Append(separator);
        }

        sb.Append(elem.Description);
    }

    return sb.ToString();
}
    
    }



}