<?php get_header(); ?>
<div id="content">
	<?php 
		if(have_posts()):
		while(have_posts()):
		the_post();
	?>
		<div class="main-post">
			<h2><a href="<?php the_permalink(); ?>"><?php the_title(); ?></a></h2> 
			<h3 class="date"><a href="<?php the_permalink(); ?>"><?php the_date();?></a></h3>
			<div class="clear-after"></div>
			<?php the_content(); ?>
		</div>
		<div id="tags">
			<?php the_tags(); ?>
		</div>
		<?php comments_template(); ?>
	<?php   
		endwhile;
		endif;
	?>
</div>
<?php get_sidebar(); ?>
<?php get_footer(); ?>
		
		
