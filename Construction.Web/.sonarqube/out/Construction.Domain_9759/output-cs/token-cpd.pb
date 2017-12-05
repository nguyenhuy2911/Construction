“
^E:\Working\Git\Construction.Web\Construction.Domain\Infrastructure\ApplicationUserDbContext.cs
	namespace		 	
Construction		
 
.		 
Domain		 
.		 
Infrastructure		 ,
{

 
public 

class $
ApplicationUserDbContext )
:* +
IdentityDbContext, =
<= >
User> B
,B C
RoleD H
,H I
stringJ P
,P Q
	UserLoginR [
,[ \
UserRole] e
,e f
	UserClaimg p
>p q
{ 
public $
ApplicationUserDbContext '
(' (
)( )
:* +
base, 0
(0 1
$str1 B
)B C
{ 	
} 	
public 
static $
ApplicationUserDbContext .
Create/ 5
(5 6
)6 7
{ 	
return 
new $
ApplicationUserDbContext /
(/ 0
)0 1
;1 2
} 	
} 
} ª
\E:\Working\Git\Construction.Web\Construction.Domain\Infrastructure\ApplicationUserManager.cs
	namespace 	
Construction
 
. 
Domain 
. 
Infrastructure ,
{ 
public 

class  
ApplicationUserStore %
:& '
	UserStore( 1
<1 2
User2 6
,6 7
Role8 <
,< =
string> D
,D E
	UserLoginF O
,O P
UserRoleQ Y
,Y Z
	UserClaim[ d
>d e
,e f

IUserStoreg q
<q r
Userr v
,v w
stringx ~
>~ 
,	 Ä
IDisposable
Å å
{ 
public  
ApplicationUserStore #
(# $$
ApplicationUserDbContext$ <
context= D
)D E
:F G
baseH L
(L M
contextM T
)T U
{V W
}X Y
} 
public 

class "
ApplicationUserManager '
:( )
UserManager* 5
<5 6
User6 :
,: ;
string< B
>B C
{ 
public "
ApplicationUserManager %
(% & 
ApplicationUserStore& :
store; @
)@ A
:B C
baseD H
(H I
storeI N
)N O
{ 	
} 	
public 
static "
ApplicationUserManager ,
Create- 3
(3 4"
IdentityFactoryOptions4 J
<J K"
ApplicationUserManagerK a
>a b
optionsc j
,j k
IOwinContextl x
context	y Ä
)
Ä Å
{ 	
var 
manager 
= 
new "
ApplicationUserManager 4
(4 5
new5 8 
ApplicationUserStore9 M
(M N
contextN U
.U V
GetV Y
<Y Z$
ApplicationUserDbContextZ r
>r s
(s t
)t u
)u v
)v w
;w x
manager 
. 
UserValidator !
=" #
new$ '
UserValidator( 5
<5 6
User6 :
>: ;
(; <
manager< C
)C D
{ *
AllowOnlyAlphanumericUserNames .
=/ 0
false1 6
,6 7
RequireUniqueEmail "
=# $
true% )
}   
;   
manager## 
.## 
PasswordValidator## %
=##& '
new##( +
PasswordValidator##, =
{$$ 
RequiredLength%% 
=%%  
$num%%! "
,%%" ##
RequireNonLetterOrDigit&& '
=&&( )
false&&* /
,&&/ 0
RequireDigit'' 
='' 
false'' $
,''$ %
RequireLowercase((  
=((! "
false((# (
,((( )
RequireUppercase))  
=))! "
false))# (
,))( )
}** 
;** 
manager-- 
.-- '
UserLockoutEnabledByDefault-- /
=--0 1
true--2 6
;--6 7
manager.. 
... )
DefaultAccountLockoutTimeSpan.. 1
=..2 3
TimeSpan..4 <
...< =
FromMinutes..= H
(..H I
$num..I J
)..J K
;..K L
manager// 
.// 0
$MaxFailedAccessAttemptsBeforeLockout// 8
=//9 :
$num//; <
;//< =
return?? 
manager?? 
;?? 
}@@ 	
}BB 
}CC ∞
^E:\Working\Git\Construction.Web\Construction.Domain\Infrastructure\DataContextDBInitializer.cs
	namespace

 	
Construction


 
.

 
Domain

 
.

 
Infrastructure

 ,
{ 
internal 
class $
DataContextDBInitializer +
:, -%
CreateDatabaseIfNotExists. G
<G H
DatabaseContextH W
>W X
{ 
	protected 
override 
void 
Seed  $
($ %
DatabaseContext% 4
context5 <
)< =
{ 	
var 
userContext 
= $
ApplicationUserDbContext 6
.6 7
Create7 =
(= >
)> ?
;? @
var 
_userManager 
= 
new ""
ApplicationUserManager# 9
(9 :
new: = 
ApplicationUserStore> R
(R S$
ApplicationUserDbContextS k
.k l
Createl r
(r s
)s t
)t u
)u v
;v w
var 
user 
= 
new 
User 
{  !
UserName" *
=+ ,
$str- 4
,4 5
Email6 ;
=< =
$str> O
}P Q
;Q R
_userManager 
. 
Create 
(  
user  $
,$ %
$str& 0
)0 1
;1 2
} 	
} 
} Ê
RE:\Working\Git\Construction.Web\Construction.Domain\Models\AspIdentityUser\Role.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
.$ %
AspIdentityUser% 4
{		 
public

 

class

 
Role

 
:

 
IdentityRole

 $
<

$ %
string

% +
,

+ ,
UserRole

- 5
>

5 6
{ 
} 
} Ó
RE:\Working\Git\Construction.Web\Construction.Domain\Models\AspIdentityUser\User.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
.$ %
AspIdentityUser% 4
{ 
public 

class 
User 
: 
IdentityUser $
<$ %
string% +
,+ ,
	UserLogin- 6
,6 7
UserRole8 @
,@ A
	UserClaimA J
>J K
{ 
public 
string 
Address 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
async 
Task 
< 
ClaimsIdentity (
>( )%
GenerateUserIdentityAsync* C
(C D"
ApplicationUserManagerD Z
manager[ b
)b c
{ 	
var 
userIdentity 
= 
await $
manager% ,
., -
CreateIdentityAsync- @
(@ A
thisA E
,E F&
DefaultAuthenticationTypesG a
.a b
ApplicationCookieb s
)s t
;t u
return 
userIdentity 
;  
} 	
} 
} û
WE:\Working\Git\Construction.Web\Construction.Domain\Models\AspIdentityUser\UserClaim.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
.$ %
AspIdentityUser% 4
{		 
public

 

class

 
	UserClaim

 
:

 
IdentityUserClaim

 .
{ 
} 
} û
WE:\Working\Git\Construction.Web\Construction.Domain\Models\AspIdentityUser\UserLogin.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
.$ %
AspIdentityUser% 4
{		 
public

 

class

 
	UserLogin

 
:

 
IdentityUserLogin

 .
{ 
} 
} ∫
VE:\Working\Git\Construction.Web\Construction.Domain\Models\AspIdentityUser\UserRole.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
.$ %
AspIdentityUser% 4
{		 
public

 

class

 
UserRole

 
:

 
IdentityUserRole

 ,
{ 
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} ¶
FE:\Working\Git\Construction.Web\Construction.Domain\Models\Category.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
{ 
public 

partial 
class 
Category !
{		 
public

 
Category

 
(

 
)

 
{ 	
this 
. 
Product_Category !
=" #
new$ '
List( ,
<, -
Product_Category- =
>= >
(> ?
)? @
;@ A
} 	
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Alias 
{ 
get !
;! "
set# &
;& '
}( )
public 
Nullable 
< 
int 
> 
Level "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
Nullable 
< 
bool 
> 
Approve %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
virtual 
ICollection "
<" #
Product_Category# 3
>3 4
Product_Category5 E
{F G
getH K
;K L
setM P
;P Q
}R S
} 
} ì
UE:\Working\Git\Construction.Web\Construction.Domain\Infrastructure\DatabaseContext.cs
	namespace 	
Construction
 
. 
Domain 
. 
Infrastructure ,
{ 
public 

partial 
class 
DatabaseContext (
:) *
	DbContext+ 4
{		 
static

 
DatabaseContext

 
(

 
)

  
{ 	
Database 
. 
SetInitializer #
(# $
new$ '$
DataContextDBInitializer( @
(@ A
)A B
)B C
;C D
} 	
public 
DatabaseContext 
( 
)  
:  !
base" &
(& '
$str' =
)= >
{ 	
} 	
public 
DbSet 
< 
Category 
> 

Categories )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
DbSet 
< 
Product 
> 
Products &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
DbSet 
< 
Product_Category %
>% &
Product_Category' 7
{8 9
get: =
;= >
set? B
;B C
}D E
public 
DbSet 
< 
Setting 
> 
Settings &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
	protected 
override 
void 
OnModelCreating  /
(/ 0
DbModelBuilder0 >
modelBuilder? K
)K L
{ 	
} 	
} 
} Ù
EE:\Working\Git\Construction.Web\Construction.Domain\Models\Product.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
{ 
public 

partial 
class 
Product  
{ 
public		 
Product		 
(		 
)		 
{

 	
this 
. 
Product_Category !
=" #
new$ '
List( ,
<, -
Product_Category- =
>= >
(> ?
)? @
;@ A
} 	
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Code 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Link 
{ 
get  
;  !
set" %
;% &
}' (
public 
Nullable 
< 
bool 
> 
Approve %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
virtual 
ICollection "
<" #
Product_Category# 3
>3 4
Product_Category5 E
{F G
getH K
;K L
setM P
;P Q
}R S
} 
} Î	
NE:\Working\Git\Construction.Web\Construction.Domain\Models\Product_Category.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
{ 
public 

partial 
class 
Product_Category )
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public		 
Nullable		 
<		 
int		 
>		 
	ProductId		 &
{		' (
get		) ,
;		, -
set		. 1
;		1 2
}		3 4
public

 
Nullable

 
<

 
int

 
>

 

CategoryId

 '
{

( )
get

* -
;

- .
set

/ 2
;

2 3
}

4 5
public 
virtual 
Category 
Category  (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
virtual 
Product 
Product &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} Ò
EE:\Working\Git\Construction.Web\Construction.Domain\Models\Setting.cs
	namespace 	
Construction
 
. 
Domain 
. 
Models $
{ 
public 

partial 
class 
Setting  
{ 
public		 
int		 
Id		 
{		 
get		 
;		 
set		  
;		  !
}		" #
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} ˘
NE:\Working\Git\Construction.Web\Construction.Domain\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str .
). /
]/ 0
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *