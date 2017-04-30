using System.Reflection;
using System.Runtime.InteropServices;
using Timex;

// Allgemeine Informationen über eine Assembly werden über die folgenden
// Attribute gesteuert. Ändern Sie diese Attributwerte, um die Informationen zu ändern,
// die mit einer Assembly verknüpft sind.
[assembly: AssemblyTitle("Timex")]
[assembly: AssemblyDescription("Zeiterfassung")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Finger & Hermsen Inc.")]
[assembly: AssemblyProduct("Timex")]
[assembly: AssemblyCopyright("Copyright © Finger & Hermsen 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Durch Festlegen von ComVisible auf "false" werden die Typen in dieser Assembly unsichtbar
// für COM-Komponenten.  Wenn Sie auf einen Typ in dieser Assembly von
// COM zugreifen müssen, legen Sie das ComVisible-Attribut für diesen Typ auf "true" fest.
[assembly: ComVisible(false)]

// Die folgende GUID bestimmt die ID der Typbibliothek, wenn dieses Projekt für COM verfügbar gemacht wird
[assembly: Guid("85d1a8eb-5d27-4ede-9fdb-dbc5e4362660")]

// Versionsinformationen für eine Assembly bestehen aus den folgenden vier Werten:
//
//      Hauptversion
//      Nebenversion
//      Buildnummer
//      Revision
//
// Sie können alle Werte angeben oder die standardmäßigen Build- und Revisionsnummern
// übernehmen, indem Sie "*" eingeben:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(Const.version+".0.0")]
[assembly: AssemblyFileVersion(Const.version + ".0.0")]