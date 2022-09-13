using System.Collections.Generic;

namespace Extension.ListExtension
{
    public static class ListExtension 
    {        
        private static readonly System.Random m_random = new System.Random();
  
        public static List<T> Shuffle<T>( this List<T> self) 
        {                        
            int n = self.Count;
            while ( 1 < n )
            {
                n--;
                int k = m_random.Next( n + 1 );
                var tmp = self[ k ];
                self[ k ] = self[ n ];
                self[ n ] = tmp;
            }
            return self;
        }
    }
}