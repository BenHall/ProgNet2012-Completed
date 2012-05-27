﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JsonFx.Serialization;
using JsonFx.Serialization.Providers;

namespace EasyHttp.Codecs.JsonFXExtensions
{
    public class RegExBasedDataReaderProvider: IDataReaderProvider
    {
        readonly IDictionary<string, IDataReader> _readersByMime = new Dictionary<string, IDataReader>(StringComparer.OrdinalIgnoreCase);

        public RegExBasedDataReaderProvider(IEnumerable<IDataReader> dataReaders)
        {
            if (dataReaders != null)
            {
                foreach (IDataReader reader in dataReaders)
                {
                    foreach (string contentType in reader.ContentType)
                    {
                        if (String.IsNullOrEmpty(contentType) ||
                            _readersByMime.ContainsKey(contentType))
                        {
                            continue;
                        }

                        _readersByMime[contentType] = reader;
                    }
                }
            }

        }

        public IDataReader Find(string contentTypeHeader)
        {
            var type = DataProviderUtility.ParseMediaType(contentTypeHeader);

            var readers = from reader in _readersByMime
                                where Regex.Match(type, reader.Key, RegexOptions.Singleline).Success
                                select reader;

            if (readers.Count() > 0)
            {
                return readers.First().Value;
            }
            return null;
        }
    }
}