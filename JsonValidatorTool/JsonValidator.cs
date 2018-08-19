#region License, Terms and Author(s)
//
// JSON Checker
// Copyright (c) 2018 Wendell Sampaio. All rights reserved.
//
//  Author(s):
//
//      Wendell Sampaio, https://wendellantildes.github.io
//
// This library is free software; you can redistribute it and/or modify it 
// under the terms of the New BSD License, a copy of which should have 
// been delivered along with this distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, 
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY 
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
#endregion

#region Original JsonChecker License, Terms and Author(s)
//
// JSON Checker
// Copyright (c) 2007 Atif Aziz. All rights reserved.
//
//  Author(s):
//
//      Atif Aziz, http://www.raboof.com
//
// This library is free software; you can redistribute it and/or modify it 
// under the terms of the New BSD License, a copy of which should have 
// been delivered along with this distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, 
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY 
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
#endregion

using System.Collections.Generic;
using System.IO;

namespace JsonValidatorTool
{
    /// <summary>
    /// The JsonValidator class contains all methods to validate json strings.
    /// </summary>
    public static class JsonValidator
    {
        /// <summary>
        /// Validates the specified json.
        /// </summary>
        /// <param name="json">Json.</param>
        /// <param name="depth">It restricts the level of maximum nesting.</param>
        /// <exception cref="JsonNotValidException"></exception>
        public static void Validate(string json, int? depth = null)
        {
            using(var reader = new StringReader(json)){
                ValidateJson(ReadChars(reader),depth);
            }
        }

        /// <summary>
        /// Validates the specified json.
        /// </summary>
        /// <param name="json">Json.</param>
        /// <param name="depth">It restricts the level of maximum nesting.</param>
        public static bool IsValid(string json, int? depth = null){
            try{
                Validate(json, depth);
                return true;
            }catch(JsonNotValidException){
                return false;
            }
        }

        static void ValidateJson(IEnumerable<char> chars, int? depth = null)
        {
            var checker = depth.HasValue ? new JsonChecker(depth.Value) : new JsonChecker();
            foreach (char ch in chars){
                checker.Check(ch);
            }
            checker.FinalCheck();
        }

        static IEnumerable<char> ReadChars(TextReader reader)
        {
            int ch = reader.Read();
            while (ch != -1)
            {
                yield return (char)ch;
                ch = reader.Read();
            }
        }
    }
}
