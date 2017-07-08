# HomeFixService
<p>
	API based web service used as a helper for a mobile application development for a school project. 
	It contains the web service code including a database scripts based on a code-first approach. 
	The application will be used for registering and searching people that are capable of doing goods for 
	the society, such as electrician, house cleaners, windows fixer, etc.  
</p>

<h3>API Usage Description</h3>

<ul>
	<li><a href="#topic_1">Registering an user</a></li>
	<li><a href="#topic_2">Getting a token</a></li>
	<li><a href="#topic_3">Getting info about the user</a></li>
	<li><a href="#topic_4">Updating user info</a></li>
	<li><a href="#topic_5">Changing a password</a></li>
	<li><a href="#topic_6">Removing user</a></li>
	<li><a href="#topic_7">Adding a contact number</a></li>
	<li><a href="#topic_8">Getting contact numbers for user</a></li>
	<li><a href="#topic_9">Updating a contact number</a></li>
	<li><a href="#topic_10">Removing a contact number</a></li>
	<li><a href="#topic_11">Adding a contact address</a></li>
	<li><a href="#topic_12">Getting contact addresses for user</a></li>
	<li><a href="#topic_13">Updating a contact address</a></li>
	<li><a href="#topic_14">Removing a contact address</a></li>
	<li><a href="#topic_15">Getting build-in enumerated professions list</a></li>
	<li><a href="#topic_16">Assigning profession to user</a></li>
	<li><a href="#topic_17">Getting assigned profession for user</a></li>
	<li><a href="#topic_18">Removing assigned profession from user</a></li>
	<li><a href="#topic_19">Getting build-in enumerated currency list</a></li>
	<li><a href="#topic_20">Adding a service for the professions assigned to user</a></li>
	<li><a href="#topic_21">Getting list of services about a profession for user</a></li>
	<li><a href="#topic_22">Getting full list of services for user independent from profession</a></li>
	<li><a href="#topic_23">Updating a service offered by user</a></li>
	<li><a href="#topic_24">Removing a service offered by user</a></li>
	<li><a href="#topic_25">Adding a work timeschedule for user</a></li>
	<li><a href="#topic_26">Getting work timeschedules for user</a></li>
	<li><a href="#topic_27">Updating a work timeschedule for user</a></li>
	<li><a href="#topic_28">Removing a work timeschedule for user</a></li>
	<li><a href="#topic_29">Adding a unavailable period for user</a></li>
	<li><a href="#topic_30">Getting unavailable periods for user in a given interval</a></li>
	<li><a href="#topic_31">Updating unavailable period for user</a></li>
	<li><a href="#topic_32">Removing unavailable period for user</a></li>
	<li><a href="#topic_33">Rating a user</a></li>
	<li><a href="#topic_34">Getting the user rating</a></li>
	<li><a href="#topic_35">Getting list of Countries</a></li>
	<li><a href="#topic_36">Getting list of Cities for a given country</a></li>
	<li><a href="#topic_37">Searching users by country name and city name</a></li>
	<li><a href="#topic_38">Searching users by profession</a></li>
	<li><a href="#topic_39">Searching users by global filter</a></li>
</ul>

<p>
	*<strong>Note</strong>: 
	&lt;&lt; Domain name &gt;&gt; will be used instead of domain name.
</p>

<h4 id="topic_1">Registering an user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/account/register</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;FirstName&quot;: &lt;&lt;string&gt;&gt;,
	&quot;LastName&quot;: &lt;&lt;string&gt;&gt;,
	&quot;UserName&quot;: &lt;&lt;string&gt;&gt;,
	&quot;Password&quot;: &lt;&lt;string&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
	&quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
	&quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
	&quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
	&quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_2">Getting a token</h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/token</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Content-Type</td>
			<td>application/x-www-form-urlencoded</td>
		</tr>
		<tr>
			<th rowspan="3">x-www-form-urlencoded parameters:</th>
			<td>grant_type</td>
			<td>password</td>
		</tr>
		<tr>
			<td>username</td>
			<td>&lt;&lt;string&gt;&gt</td>
		</tr>
		<tr>
			<td>password</td>
			<td>&lt;&lt;string&gt;&gt</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;access_token&quot;: &lt;&lt;string&gt;&gt;
    &quot;token_type&quot;: &quot;bearer&quot;,
    &quot;expires_in&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_3">Getting info about the user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/account/user</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_4">Updating user info<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/account/user</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;FirstName&quot;:&lt;&lt;string&gt;&gt;,
	&quot;LastName&quot;:&lt;&lt;string&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
	&quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
	&quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
	&quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
	&quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_5">Changing a password<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/account/changePassword</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;Username&quot;:&lt;&lt;string&gt;&gt;,
	&quot;OldPassword&quot;:&lt;&lt;string&gt;&gt;,
	&quot;NewPassword&quot;:&lt;&lt;string&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_6">Removing user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">DELETE</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/account/user</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;Username&quot;:&lt;&lt;string&gt;&gt;,
	&quot;Password&quot;:&lt;&lt;string&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_7">Adding a contact number<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/number</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;PhoneNumber&quot;: &lt;&lt;string&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;PhoneNumber&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>


<h4 id="topic_8">Getting contact numbers for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/number</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;PhoneNumber&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;PhoneNumber&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_9">Updating a contact number<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">PUT</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/number</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;PhoneNumber&quot;: &lt;&lt;string&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;PhoneNumber&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_10">Removing a contact number<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">DELETE</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/number</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_11">Adding a contact address<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/address</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;StreetName&quot;: &lt;&lt;string&gt;&gt;,
    &quot;City&quot;: &lt;&lt;string&gt;&gt;,
    &quot;Country&quot;: &lt;&lt;string&gt;&gt;,
    &quot;Latitude&quot;: &lt;&lt;decimal&gt;&gt;, 
    &quot;Longitude&quot;: &lt;&lt;decimal&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;StreetName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;City&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Country&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Latitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;Longitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>


<h4 id="topic_12">Getting contact addresses for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/address</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;StreetName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;City&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Country&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Latitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;Longitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;StreetName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;City&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Country&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Latitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;Longitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_13">Updating a contact address<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">PUT</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/address</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;StreetName&quot;: &lt;&lt;string&gt;&gt;,
    &quot;City&quot;: &lt;&lt;string&gt;&gt;,
    &quot;Country&quot;: &lt;&lt;string&gt;&gt;,
    &quot;Latitude&quot;: &lt;&lt;decimal&gt;&gt;, 
    &quot;Longitude&quot;: &lt;&lt;decimal&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;StreetName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;City&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Country&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Latitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;Longitude&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_14">Removing a contact address<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">DELETE</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/contact/address</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_15">Getting build-in enumerated professions list<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/professionList</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;ProfessionName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ProfessionDescription&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;ProfessionName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ProfessionDescription&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_16">Assigning profession to user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/type</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;ProfessionToAssign&quot;:&lt;&lt;integer&gt;&gt;
} </pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;ProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheProfession&gt;k__BackingField&quot;: {
        &quot;&lt;ProfessionName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
        &quot;&lt;ProfessionDescription&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
        &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>


<h4 id="topic_17">Getting assigned profession for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/type</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;ProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheProfession&gt;k__BackingField&quot;: {
        &quot;&lt;ProfessionName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
        &quot;&lt;ProfessionDescription&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
        &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;ProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheProfession&gt;k__BackingField&quot;: {
        &quot;&lt;ProfessionName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
        &quot;&lt;ProfessionDescription&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
        &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_18">Removing assigned profession from user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">DELETE</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;api/profession/type</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_19">Getting build-in enumerated currency list<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/currencyList</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
    &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
    &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
    &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
    &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_20">Adding a service for a profession assigned to user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/service</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
        &quot;UserProfessionId&quot;:&lt;&lt;integer&gt;&gt;,
        &quot;ServiceName&quot;:&lt;&lt;string&gt;&gt;,
        &quot;ServiceUnit&quot;:&lt;&lt;string&gt;&gt;,
        &quot;ServiceUnitPrice&quot;:&lt;&lt;decimal&gt;&gt;,
        &quot;Currency&quot;:&lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;ServiceName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnit&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnitPrice&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;ServiceUnitId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheCurrencyUsed&gt;k__BackingField&quot;: {
        &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
        &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
        &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;UserProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>


<h4 id="topic_21">Getting list of services about a profession for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/service</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>professionId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;ServiceName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnit&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnitPrice&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;ServiceUnitId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheCurrencyUsed&gt;k__BackingField&quot;: {
        &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
        &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
        &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;UserProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;ServiceName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnit&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnitPrice&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;ServiceUnitId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheCurrencyUsed&gt;k__BackingField&quot;: {
        &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
        &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
        &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;UserProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_22">Getting full list of services for user independent from profession<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/service</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;ServiceName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnit&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnitPrice&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;ServiceUnitId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheCurrencyUsed&gt;k__BackingField&quot;: {
        &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
        &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
        &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;UserProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;ServiceName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnit&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnitPrice&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;ServiceUnitId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheCurrencyUsed&gt;k__BackingField&quot;: {
        &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
        &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
        &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;UserProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_23">Updating a service offered by user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">PUT</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/service</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;ServiceName&quot;:&lt;&lt;string&gt;&gt;,
    &quot;ServiceUnit&quot;:&lt;&lt;string&gt;&gt;,
    &quot;ServiceUnitPrice&quot;:&lt;&lt;decimal&gt;&gt;,
    &quot;Currency&quot;:&lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;ServiceName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnit&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;ServiceUnitPrice&gt;k__BackingField&quot;: &lt;&lt;decimal&gt;&gt;,
    &quot;&lt;ServiceUnitId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;TheCurrencyUsed&gt;k__BackingField&quot;: {
        &quot;CurrencySign&quot;: &lt;&lt;string&gt;&gt;,
        &quot;CurrencyFullName&quot;: &lt;&lt;string&gt;&gt;,
        &quot;Id&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;&lt;UserProfessionId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_24">Removing a service offered by user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">DELETE</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/profession/service</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_25">Adding a work timeschedule for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/work</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;UtcHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;UtcMinutes&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartHours&quot;:&lt;&lt;integer&gt;&gt;, 
	&quot;StartMinutes&quot;:&lt;&lt;integer&gt;&gt;, 
	&quot;EndDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndMinutes&quot;:&lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;StartDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;StartTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;EndDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;EndTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>


<h4 id="topic_26">Getting work timeschedules for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/work</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;StartDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;StartTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;EndDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;EndTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;StartDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;StartTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;EndDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;EndTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_27">Updating a work timeschedule for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">PUT</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/work</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;UtcHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;UtcMinutes&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartHours&quot;:&lt;&lt;integer&gt;&gt;, 
	&quot;StartMinutes&quot;:&lt;&lt;integer&gt;&gt;, 
	&quot;EndDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndMinutes&quot;:&lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;StartDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;StartTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;EndDay&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;EndTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_28">Removing a work timeschedule for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">DELETE</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/work</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_29">Adding a unavailable period for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/busy</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;UtcHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;UtcMinutes&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartYear&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartMonth&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartMinutes&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndYear&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndMonth&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndMinutes&quot;:&lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;BusyPeriodStartOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;BusyPeriodEndsOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>


<h4 id="topic_30">Getting unavailable periods for user in a given interval<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/busy</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="12">URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>UtcHours</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>StartYear</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>StartMonth</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>StartDay</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>StartHours</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>StartMinutes</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>EndYear</td>
			<td>&lt;&lt;integer&gt;&gt;</td
		</tr>
		<tr>
			<td>EndMonth</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>EndDay</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>EndHours</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>EndMinutes</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or more JSON objects: 
<pre>[
{
    &quot;&lt;BusyPeriodStartOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;BusyPeriodEndsOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;BusyPeriodStartOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;BusyPeriodEndsOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_31">Updating unavailable period for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">PUT</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/busy</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;UtcHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;UtcMinutes&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartYear&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartMonth&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;StartMinutes&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndYear&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndMonth&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndDay&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndHours&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;EndMinutes&quot;:&lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;&lt;BusyPeriodStartOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;BusyPeriodEndsOn&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_32">Removing unavailable period for user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">DELETE</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/schedule/busy</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Authorization</td>
			<td>bearer &lt;&lt;token value&gt;&gt;</td>
		</tr>
		<tr>
			<th>URI Parameters:</th>
			<td>id</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text: 
<pre>true</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;token value&gt;&gt; means that the API is expecting an access_token value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_33">Rating a user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/feedback/rate</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<th>Body Context:</th>
			<td colspan="2">
			JSON object: 
<pre>{
	&quot;UserId&quot;:&lt;&lt;integer&gt;&gt;,
	&quot;Points&quot;:&lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		<tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON object: 
<pre>{
    &quot;Key&quot;: {
        &quot;&lt;FeedbackDateTime&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
        &quot;&lt;FeedbackPoints&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
        &quot;&lt;UserId&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
        &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
    },
    &quot;Value&quot;: &lt;&lt;integer&gt;&gt;
}</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>


<h4 id="topic_34">Getting the user rating<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/feedback/rate</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>userId</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			Plain Text:
<pre>&lt;&lt;decimal&gt;&gt;</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_35">Getting list of Countries<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/search/listCountry</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th>URI Parameters:</th>
			<td>countryCriteria</td>
			<td>&lt;&lt;string&gt;&gt; &lt;&lt;optional&gt;&gt;>></td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or mode strings:
<pre>[
	&lt;&lt;string&gt;&gt;,
	&lt;&lt;string&gt;&gt;
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;optional&gt;&gt; means that the API can accept empty string as value. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_36">Getting list of Cities for a given country<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/search/listCityForCountry</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="2">URI Parameters:</th>
			<td>countryName</td>
			<td>&lt;&lt;string&gt;&gt;</td>
		</tr>
		<tr>
			<td>cityCriteria</td>
			<td>&lt;&lt;string&gt;&gt; &lt;&lt;optional&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or mode strings:
<pre>[
	&lt;&lt;string&gt;&gt;,
	&lt;&lt;string&gt;&gt;
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;optional&gt;&gt; means that the API can accept empty string as value. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_37">Searching users by country name and city name<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/search/searchByCountryAndCity</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="5">URI Parameters:</th>
			<td>CountryName</td>
			<td>&lt;&lt;string&gt;&gt;</td>
		</tr>
		<tr>
			<td>CityName</td>
			<td>&lt;&lt;string&gt;&gt;</td>
		</tr>
		<tr>
			<td>SearchTerm</td>
			<td>&lt;&lt;string&gt;&gt; &lt;&lt;optional&gt;&gt;</td>
		</tr>
		<tr>
			<td>PageSize</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>PageNumber</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or mode JSON objects:
<pre>[
{
    &quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;optional&gt;&gt; means that the API can accept empty string as value. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_38">Searching users by profession<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/search/searchByProfession</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="6">URI Parameters:</th>
			<td>Profession</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>CurrentLatitude</td>
			<td>&lt;&lt;decimal&gt;&gt;</td>
		</tr>
		<tr>
			<td>CurrentLongitude</td>
			<td>&lt;&lt;decimal&gt;&gt;</td>
		</tr>
		<tr>
			<td>SearchTerm</td>
			<td>&lt;&lt;string&gt;&gt; &lt;&lt;optional&gt;&gt;</td>
		</tr>
		<tr>
			<td>PageSize</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>PageNumber</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or mode JSON objects:
<pre>[
{
    &quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;optional&gt;&gt; means that the API can accept empty string as value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>

<h4 id="topic_39">Searching users by global filter<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">GET</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">&lt;&lt; Domain name &gt;&gt;/api/search/generalSearch</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="5">URI Parameters:</th>
			<td>CurrentLatitude</td>
			<td>&lt;&lt;decimal&gt;&gt;</td>
		</tr>
		<tr>
			<td>CurrentLongitude</td>
			<td>&lt;&lt;decimal&gt;&gt;</td>
		</tr>
		<tr>
			<td>SearchTerm</td>
			<td>&lt;&lt;string&gt;&gt; &lt;&lt;optional&gt;&gt;</td>
		</tr>
		<tr>
			<td>PageSize</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<td>PageNumber</td>
			<td>&lt;&lt;integer&gt;&gt;</td>
		</tr>
		<tr>
			<th>The returned result:</th>
			<td colspan="2">
			JSON array of zero or mode JSON objects:
<pre>[
{
    &quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
},
{
    &quot;&lt;UserFirstName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;UserLastName&gt;k__BackingField&quot;: &lt;&lt;string&gt;&gt;,
    &quot;&lt;RatingSum&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;RatingCount&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;,
    &quot;&lt;Id&gt;k__BackingField&quot;: &lt;&lt;integer&gt;&gt;
}
]</pre>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3">&lt;&lt;string&gt;&gt; means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;integer&gt;&gt; means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;optional&gt;&gt; means that the API can accept empty string as value. </th>
		</tr>
		<tr>
			<th colspan="3">&lt;&lt;decimal&gt;&gt; means that the API is expecting or returning a 32-bit floating point number. </th>
		</tr>
	</tfooter>
</table>