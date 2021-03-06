﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BSPHeader
{
    int version;

    List<BSPDirectoryEntry> DirectoryEntries;

    public BSPHeader( BinaryReader bspFile )
    {
        DirectoryEntries = new List<BSPDirectoryEntry>();

        bspFile.BaseStream.Seek( 0, SeekOrigin.Begin );
        version = bspFile.ReadInt32();
        Debug.Log("Version: " + version);

        for ( int i = 0; i < (int)DIRECTORY_ENTRY.COUNT; i++ )
        {
            BSPDirectoryEntry entry = new BSPDirectoryEntry( bspFile );
            DirectoryEntries.Add( entry );
        }
    }

    public BSPDirectoryEntry GetDirectoryEntry( DIRECTORY_ENTRY type )
    {
    	return DirectoryEntries[ (int)type ];
    }
}
