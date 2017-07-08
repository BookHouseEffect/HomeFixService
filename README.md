# HomeFixService
<h1>HomeFixService</h3>
<hr>
<p>
	API based web service used as a helper for a mobile application development for a school project. 
	It contains the web service code including a database scripts based on a code-first approach. 
	The application will be used for registering and searching people that are capable of doing goods for 
	the society, such as electrician, house cleaners, windows fixer, etc.  
</p>

<h3>API Usage Description</h3>

<p>
	*<strong>Note</strong>: 
	"&lt;&lt; Domain name &gt;&gt" will be used instead of domain name.
</p>

<h4>Registering an user<h4>

<table>
	<thead>
		<tr>
			<th>Method type:</th>
			<td colspan="2">POST</td>
		</tr>
		<tr>
			<th>Route:</th>
			<td colspan="2">"&lt;&lt; Domain name &gt;&gt/api/account/register"</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th rowspan="1">Headers:</th>
			<td>Content-Type</td>
			<td>application/json</td>
		</tr>
		<tr>
			<th>Body Context</th>
			<td colspan="2">
				<code>
					{
						"FirstName": <<string>>,
						"LastName":	<<string>>,
						"UserName": <<string>>,
						"Password": <<string>>
					}
				</code>
			</td>
		<tr>
		<tr>
			<th>The returned result</th>
			<td colspan="2">
				<code>
					{
						"<UserFirstName>k__BackingField": <<string>>,
						"<UserLastName>k__BackingField": <<string>>,
						"<RatingSum>k__BackingField": <<integer>>,
						"<RatingCount>k__BackingField": <<integer>>,
						"<Id>k__BackingField": <<integer>>
					}
				</code>
			</td>
		</tr>
	</tbody>
	<tfooter>
		<tr>
			<th colspan="3"><<string>> means that the API is expecting or returning a string object. </th>
		</tr>
		<tr>
			<th colspan="3"><<integer>> means that the API is expecting or returning a 32-bit integer. </th>
		</tr>
	</tfooter>
</table>