for b in {master,type-system}
do
	for r in {origin,github,codeplex}
	do
		git push $r $b
	done
done
