// Generated by Haxe 4.3.1

#pragma warning disable 109, 114, 219, 429, 168, 162
public class Std {
	
	public Std() {
	}
	
	
	public static bool isOfType(object v, object t) {
		unchecked {
			if (( v == null )) {
				return false;
			}
			
			if (( t == null )) {
				return false;
			}
			
			global::System.Type clt = ( t as global::System.Type );
			if (global::haxe.lang.Runtime.typeEq(clt, null)) {
				return false;
			}
			
			switch (clt.ToString()) {
				case "System.Boolean":
				{
					return v is bool;
				}
				
				
				case "System.Double":
				{
					return v is double || v is int;
				}
				
				
				case "System.Int32":
				{
					return global::haxe.lang.Runtime.isInt(v);
				}
				
				
				case "System.Object":
				{
					return true;
				}
				
				
			}
			
			global::System.Type vt = v.GetType();
			if (clt.IsAssignableFrom(((global::System.Type) (vt) ))) {
				return true;
			}
			
			{
				global::System.Type[] _g_arr = clt.GetInterfaces();
				uint _g_idx = ((uint) (0) );
				while (( _g_idx < ( _g_arr as global::System.Array ).Length )) {
					_g_idx += ((uint) (1) );
					global::System.Type iface = ((global::System.Type) (_g_arr[((int) (((uint) (( _g_idx - 1 )) )) )]) );
					global::haxe.lang.GenericInterface g = global::haxe.lang.Runtime.getGenericAttr(iface);
					if (( ( g != null ) && global::haxe.lang.Runtime.typeEq(g.generic, clt) )) {
						return iface.IsAssignableFrom(((global::System.Type) (vt) ));
					}
					
				}
				
			}
			
			return false;
		}
	}
	
	
	public static string @string(object s) {
		if (( s == null )) {
			return "null";
		}
		
		if (( s is bool )) {
			if (global::haxe.lang.Runtime.toBool(s)) {
				return "true";
			}
			else {
				return "false";
			}
			
		}
		
		return s.ToString();
	}
	
	
	public static int @int(double x) {
		return ((int) (x) );
	}
	
	
	public static int random(int x) {
		if (( x <= 0 )) {
			return 0;
		}
		
		return global::HaxeMath.rand.Next(((int) (x) ));
	}
	
	
}


