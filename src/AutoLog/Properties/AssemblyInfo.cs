using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Setting InternalsVisibleTo allows another assembly access items
// that are marked with the 'internal' access modifier.
[assembly: InternalsVisibleTo("ClassFinderTests")]
[assembly: InternalsVisibleTo("LoggableItemTests")]

[assembly: ComVisibleAttribute(false)]