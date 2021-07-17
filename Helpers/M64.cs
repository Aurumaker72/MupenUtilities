using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MupenUtilities.Helpers
{
    public static class M64
    {
        public struct MovieStruct
        {
            public uint magic;    // M64\0x1a
            public uint version;  // 3
            public uint uid;      // used to match savestates to a particular movie

            public uint length_vis; // number of "frames" in the movie
            public uint rerecord_count;
            public byte vis_per_second; // "frames" per second
            public byte num_controllers;
            public ushort reserved1;
            public uint length_samples;

            public ushort startFlags; // should equal 2 if the movie is from a clean start
            public ushort reserved2;
            public uint controllerFlags;
            public uint reservedFlags;

            public string oldAuthorInfo;
            public string oldDescription;
            public string romNom; // internal rom name
            public uint romCRC;
            public ushort romCountry;
            public string reservedBytes;
            public string videoPluginName;
            public string soundPluginName;
            public string inputPluginName;
            public string rspPluginName;
            public string authorInfos; // utf8-encoded
            public string description; // utf8-encoded


        }

        public static MovieStruct ParseMovie(string Path)
        {
            FileStream fs = new FileStream(Path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            MovieStruct movieData = new MovieStruct();

            movieData.magic = br.ReadUInt32();
            movieData.version = br.ReadUInt32();
            movieData.uid = br.ReadUInt32();
            movieData.length_vis = br.ReadUInt32();
            movieData.rerecord_count = br.ReadUInt32();
            movieData.vis_per_second = br.ReadByte();
            movieData.num_controllers = br.ReadByte();
            br.ReadBytes(2);
            movieData.length_samples = br.ReadUInt32();
            movieData.startFlags = br.ReadUInt16();
            br.ReadBytes(2);
            movieData.controllerFlags = br.ReadUInt32();
            br.ReadBytes(160);
            movieData.romNom = Encoding.ASCII.GetString(br.ReadBytes(32));
            movieData.romCRC = br.ReadUInt32();
            movieData.romCountry = br.ReadUInt16();
            br.ReadBytes(56);

            movieData.videoPluginName = Encoding.ASCII.GetString(br.ReadBytes(64));
            movieData.soundPluginName = Encoding.ASCII.GetString(br.ReadBytes(64));
            movieData.inputPluginName = Encoding.ASCII.GetString(br.ReadBytes(64));
            movieData.rspPluginName = Encoding.ASCII.GetString(br.ReadBytes(64));

            movieData.authorInfos = Encoding.ASCII.GetString(br.ReadBytes(222));
            movieData.description = Encoding.ASCII.GetString(br.ReadBytes(256));

            fs.Close(); br.Close();
            return movieData;
        }
    }
}
