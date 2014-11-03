<?php get_header(); ?>
<div id="content">
	<div class="main-post">
		<?php
			$args = array( 'numberposts' => 1, 'post_parent' => 'div', );
			$lastposts = get_posts( $args );
			foreach($lastposts as $post) : setup_postdata($post); ?>
		<?php endforeach; ?>
		<h2><a href="<?php the_permalink(); ?>"><?php the_title(); ?></a></h2> 
		<h3 class="date"> | <a href="<?php the_permalink(); ?>"><?php the_date();?></a></h3>
		<div class="clear-after"></div>
		<div>
			<?php the_content(); ?>
		</div>
	</div>
	<div id="other-posts">
		<?php
		$args = array( 'numberposts' => 3, 'post_parent' => 'div', );
		$lastposts = get_posts( $args );
		foreach($lastposts as $post) : setup_postdata($post); ?>
			<div>
				<h4>POSTED BY  <?php the_author(); ?>  IN BLOG UPDATES | <?php the_date(); ?></h4>
				<h3><a href="<?php the_permalink(); ?>"><?php the_title(); ?></a></h3> 
				<?php the_content(); ?>
			</div>
		<?php endforeach; ?>
	</div>
	<div id="content-widgets">
		<?php if(!dynamic_sidebar('content-widgets')): ?>
		<div>
			<h4>recent comments</h4>
			<a href="#">Kevin Paquet on Theme Updates Round 3 + Theme Sneak-Peek</a>
			<a href="#">parsifal on Theme Updates Round 3 + Theme Sneak-Peek</a>
			<a href="#">Andrew on Theme Updates Round 3 + Theme Sneak-Peek</a>
			<a href="#">Farida on Theme Updates Round 3 + Theme Sneak-Peek</a>
			<a href="#">Micheal on Theme Updates Round 3 + Theme Sneak-Peek</a>
		</div>
		<div>
			<h4>popular articles</h4>
			<a href="#">Theme Updates Round 3 + Theme Sneak-Peek</a>
			<a href="#">Theme Updates Round 2 + A Small Surprise</a>
			<a href="#">Theme Updates - Round One</a>
			<a href="#">Theme Sneak Peek: Glow</a>
			<a href="#">New Theme: ColdStone</a>
		</div>
		<div>
			<h4>random articles</h4>
			<a href="#">Theme Updates Round 3 + Theme Sneak-Peek</a>
			<a href="#">Theme Updates Round 2 + A Small Surprise</a>
			<a href="#">Theme Updates - Round One</a>
			<a href="#">Theme Sneak Peek: Glow</a>
			<a href="#">New Theme: ColdStone</a>
		</div>
		<?php endif; ?>
	</div>
</div>
<?php get_sidebar(); ?>
<?php get_footer(); ?>