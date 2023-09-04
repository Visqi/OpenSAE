// Generated by Haxe 4.3.1

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace geometrize._ArraySet {
	public sealed class ArraySet_Impl_ {
		
		public static global::HaxeArray<T> create<T>(global::HaxeArray<T> array) {
			if (( array == null )) {
				return ((global::HaxeArray<T>) (new global::HaxeArray<T>(new T[]{})) );
			}
			
			return global::geometrize._ArraySet.ArraySet_Impl_.toSet<T>(((global::HaxeArray<T>) (array) ));
		}
		
		
		public static global::HaxeArray<T> intersection<T>(global::HaxeArray<T> this1, global::HaxeArray<T> @set) {
			global::HaxeArray<T> result = new global::HaxeArray<T>(new T[]{});
			{
				int _g = 0;
				while (( _g < this1.length )) {
					T element = this1[_g];
					 ++ _g;
					if (global::geometrize._ArraySet.ArraySet_Impl_.contains<T>(((global::HaxeArray<T>) (@set) ), global::haxe.lang.Runtime.genericCast<T>(element))) {
						result.push(element);
					}
					
				}
				
			}
			
			return ((global::HaxeArray<T>) (result) );
		}
		
		
		public static global::HaxeArray<T> union<T>(global::HaxeArray<T> this1, global::HaxeArray<T> @set) {
			return global::geometrize._ArraySet.ArraySet_Impl_.toSet<T>(((global::HaxeArray<T>) (this1.concat(global::geometrize._ArraySet.ArraySet_Impl_.toArray<T>(((global::HaxeArray<T>) (@set) )))) ));
		}
		
		
		public static global::HaxeArray<T> unionArray<T>(global::HaxeArray<T> this1, global::HaxeArray<T> array) {
			return global::geometrize._ArraySet.ArraySet_Impl_.toSet<T>(((global::HaxeArray<T>) (this1.concat(array)) ));
		}
		
		
		public static global::HaxeArray<T> difference<T>(global::HaxeArray<T> this1, global::HaxeArray<T> @set) {
			global::HaxeArray<T> result = ((global::HaxeArray<T>) (((global::HaxeArray<T>) (this1) ).copy()) );
			{
				int _g = 0;
				global::HaxeArray<T> _g1 = ((global::HaxeArray<T>) (@set) );
				while (( _g < _g1.length )) {
					T element = _g1[_g];
					 ++ _g;
					result.@remove(element);
				}
				
			}
			
			return ((global::HaxeArray<T>) (global::geometrize._ArraySet.ArraySet_Impl_.toArray<T>(((global::HaxeArray<T>) (result) ))) );
		}
		
		
		public static bool @add<T>(global::HaxeArray<T> this1, T element) {
			if (global::haxe.lang.Runtime.eq(element, default(T))) {
				//throw ((global::System.Exception) (global::haxe.Exception.thrown("FAIL: element != null")) );
			}
			
			if (global::geometrize._ArraySet.ArraySet_Impl_.contains<T>(((global::HaxeArray<T>) (this1) ), global::haxe.lang.Runtime.genericCast<T>(element))) {
				return false;
			}
			
			this1.push(element);
			return true;
		}
		
		
		public static bool contains<T>(global::HaxeArray<T> this1, T element) {
			{
				int _g = 0;
				while (( _g < this1.length )) {
					T i = this1[_g];
					 ++ _g;
					if (global::haxe.lang.Runtime.eq(i, element)) {
						return true;
					}
					
				}
				
			}
			
			return false;
		}
		
		
		public static global::HaxeArray<T> copy<T>(global::HaxeArray<T> this1) {
			return ((global::HaxeArray<T>) (this1.copy()) );
		}
		
		
		public static global::HaxeArray<T> slice<T>(global::HaxeArray<T> this1, int position, global::haxe.lang.Null<int> end) {
			return ((global::HaxeArray<T>) (this1.slice(position, end)) );
		}
		
		
		public static global::HaxeArray<T> splice<T>(global::HaxeArray<T> this1, int position, int length) {
			return ((global::HaxeArray<T>) (this1.splice(position, length)) );
		}
		
		
		public static global::HaxeArray<T> toArray<T>(global::HaxeArray<T> this1) {
			return this1.copy();
		}
		
		
		public static global::HaxeArray<T> toSet<T>(global::HaxeArray<T> array) {
			global::HaxeArray<T> @set = ((global::HaxeArray<T>) (new global::HaxeArray<T>(new T[]{})) );
			{
				int _g = 0;
				while (( _g < array.length )) {
					T v = array[_g];
					 ++ _g;
					global::geometrize._ArraySet.ArraySet_Impl_.@add<T>(((global::HaxeArray<T>) (@set) ), global::haxe.lang.Runtime.genericCast<T>(v));
				}
				
			}
			
			return @set;
		}
		
		
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		public static global::HaxeArray<T> _new<T>(global::HaxeArray<T> array) {
			return ((global::HaxeArray<T>) (array) );
		}
		
		
	}
}


