# Step 1
	open the file specified on the command line and write its contents to standard out.
	**Example:**
		% cccat test.txt

# Step 2
	read the input from from standard in
	**Example:**
		% head -n1 test.txt | cccat -

# Step 3
	In this step your goal is to concatenate files.
	**Example:**
		% cccat test.txt test2.txt

# Step 4
	In this step your goal is to number the lines as they’re printed out,
	**Example:**
		% head -n3 test.txt | cccat -n
	Free free not to use head, I’m just keeping the example short

# Step 5
	In this step your goal is to number lines, both including and excluding non-blank lines, 
	**Example:**
		% sed G test.txt | cccat -n | head -n4
		% sed G test.txt | cccat -b | head -n5
